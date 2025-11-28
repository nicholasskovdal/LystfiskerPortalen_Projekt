namespace LystfiskerPortalen.Models
{
    public class Post
    {
        public class Opslag
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public string Bait { get; set; }

            public string Location { get; set; }
            public string Technique { get; set; }
            public string ImageUrl { get; set; }
            public string Inspiration { get; set; }


        }
    }
}
