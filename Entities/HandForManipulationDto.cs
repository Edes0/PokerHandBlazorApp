namespace Entities
{
    public abstract record HandForManipulationDto
    {
        public Guid Id { get; set; }

        public List<Card>? Cards { get; set; }

        public string StringOfCards { get; set; }
    }
}
