using System.Text.Json.Serialization;

namespace OneriApi.Entities
{
    public class ShoeSize
    {
        public int Id { get; set; }

        public int ShoeId { get; set; }

        public int Size { get; set; }

        public decimal InnerLength { get; set; }

        public decimal? ForefootWidth { get; set; }
        [JsonIgnore]
        public Shoe? Shoe { get; set; } = null!;
    }
}
