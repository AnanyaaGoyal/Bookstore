namespace BookStore.Api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public int Price { get; set; }
    }
}
