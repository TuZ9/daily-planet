
namespace daily_planet_domain.Entities
{
    public class News
    {
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public required string Url { get; set; }
        public required DateTime DataPublicacao { get; set; }
    }
}
