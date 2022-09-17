using Entities;

namespace Shared.DataTransferObjects
{
    public record HandDto(Guid Id, List<Card>? Cards, string StringOfCards)
    {
    }
}
    