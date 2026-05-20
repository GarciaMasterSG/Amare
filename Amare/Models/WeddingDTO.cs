namespace Amare.Models
{
    public class WeddingDTO : WeddingLocationAndDateDTO
    {
        public int Id { get; set; }

        public string WeddingCode { get; set; }

        public string Groom {  get; set; }

        public string Bride { get; set; }
    }
}
