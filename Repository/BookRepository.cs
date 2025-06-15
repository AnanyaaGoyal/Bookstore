using BookStore.Api.Models;

namespace BookStore.Api.Repository
{
    public class BookRepository
    {
        List<Book> books = new List<Book>()
        {
                   new Book
                {
                    Id = 1,
                    Name = "Learning C#",
                    Description = "This book will give deep insights about C#.",
                    Price = 1000,
                    DisLikes = 10,
                    Likes = 100,
                },

                new Book
                {
                    Id = 2,
                    Name = "Learning Testing",
                    Description = "This is for teaching from basic to advance level of testing.",
                    Price = 1200,
                    DisLikes = 13,
                    Likes = 67,
                },

                new Book
                {
                    Id = 3,
                    Name = "Mastering Unit Testing in .NET Core",
                    Description = "This is a series in which every framework of Unit testing will be explained",
                    Price = 500,
                    DisLikes = 0,
                    Likes = 100,
                }
        };

        public async Task<Book> deleteBook(int id)
        {
            var book = books.Where(b => b.Id == id).FirstOrDefault();
            if (book == null)
            {
                throw new InvalidOperationException("Id is not found");
            }
            books.Remove(book);
            return await Task.Run(() => book);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await Task.Run(() => books.ToList());
        }

        public async Task<Book> GetBook(int id)
        {
            Book? book = books.Where(b => b.Id == id).FirstOrDefault();
            if (book == null)
                throw new InvalidOperationException("Id is not found");

            return await Task.Run(() => book);
        }

        public async Task<Book> PostBook(Book newBook)
        {
            books.Add(newBook);
            return await Task.Run(() => newBook);
        }

        public async Task<Book> PutBook(int id, Book book)
        {
            int indexToUpdate = books.FindIndex(b => b.Id == id);
            if(indexToUpdate == -1)
                throw new InvalidOperationException("Id is not found");

            books[indexToUpdate].Price = book.Price;
            books[indexToUpdate].Description = book.Description;
            books[indexToUpdate].Likes = book.Likes;
            books[indexToUpdate].DisLikes = book.DisLikes;
            books[indexToUpdate].Name = book.Name;

            return await Task.FromResult(books[indexToUpdate]);
        }
    }
}
