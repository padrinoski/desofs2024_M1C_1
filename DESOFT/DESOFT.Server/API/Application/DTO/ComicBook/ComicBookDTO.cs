namespace DESOFT.Server.API.Application.DTO.ComicBook
{
    public class ComicBookDTO
    {
        public int ComicBookId { get; set; }
        public string Version { get; set; }
        public DateTime PublishingDate { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

    }
}
