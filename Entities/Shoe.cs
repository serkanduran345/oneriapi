namespace OneriApi.Entities
{
    public class Shoe
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<ShoeSize> Sizes { get; set; } = new List<ShoeSize>();
    }
}
