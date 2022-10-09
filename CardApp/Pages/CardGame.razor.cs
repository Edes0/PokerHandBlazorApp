﻿@page "/CardGame"

@using Models
@using Service.Contracts

@inject IServiceManager serviceManager

<h3>CardGame</h3>

@if (hand is null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table class="table table-striped">
        <thead>
            <tr>
                <th>Card</th>
                <th><input type="checkbox" name="select-all" id="select-all" /></th>
            </tr>
        </thead>
        <tbody>
            @foreach (var card in hand.Cards)
            {
                <tr>
                    <td>@card.RankChar @card.SuitChar</td>
                    <td><input type="checkbox" @bind="card.IsChecked"/></td>
                </tr>
            }
        </tbody>
    </table>
    <button class="btn btn-danger" @onclick="UpdateHand">Swap Cards</button>
}

@code {
    CardDeckModel cardDeck = new(1);
    CardDeckModel? throwDeck = new(0);
    HandModel? hand = new();

    protected override async Task OnInitializedAsync()
    {
        ShuffleCardDeck();
        await AddCardsToHand(5);
    }

    private void ShuffleCardDeck()
    {
        cardDeck.Shuffle();
    }

    /// <summary>
    /// Add "amount" cards to hand. If there is not enough cards in the deck, refill it with the help of 
    /// method "MergeThrowDeckAndCardDeck".
    /// 
    /// Remove 
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    private async Task AddCardsToHand(int amount)
    {
        if (amount is 0) return;
        if (cardDeck.Count() < amount) MergeThrowDeckAndCardDeck();

        hand.Cards.AddRange(cardDeck.TakeCardsFromDeck(amount));
        hand.Cards = hand.Cards; //TODO: Observern går endast genom settern och inte efter AddRange.
        await serviceManager.HandService.CreateHandAsync(hand);
    }

    ///Updates hand. Removes cards to be thrown and add new ones
    private async void UpdateHand()
    {
        int AmountToThrow;
        throwDeck.Cards.AddRange(hand.ThrowCheckedCardsAndRemoveThemFromHand(out AmountToThrow));
        await AddCardsToHand(AmountToThrow);
    }

    ///Merging decks if the carddeck doesnt have enough cards
    private void MergeThrowDeckAndCardDeck()
    {
        cardDeck.Cards.AddRange(throwDeck);
        throwDeck.Cards.Clear();
        ShuffleCardDeck();
    }
}
