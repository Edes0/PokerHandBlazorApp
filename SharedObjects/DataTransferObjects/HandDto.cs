using Entities;

namespace SharedObjects.DataTransferObjects
{
    public record HandDto(Guid Id, List<Card>? Cards, string StringOfCards)
    {
    }
}
    