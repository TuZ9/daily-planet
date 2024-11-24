
namespace daily_planet_domain.Entities
{
    public class News
    {
        public News(){}
        public News(Guid idContent, string title, string description, string url, DateTime datePublication)
        {
            IdContent = idContent;
            Title = title;
            Description = description;
            Url = url;
            DatePublication = datePublication;
        }

        public required Guid IdContent { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Url { get; set; }
        public required DateTime DatePublication { get; set; }
    }
}
