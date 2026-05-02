using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using ZapataLibraryNowAPI.Models;

namespace ZapataLibraryNowAPI.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<book> books = new List<book>
       {
            new book {
            Id = 1, 
            Title = "Mein Kampf",
            Author = "Adolf Hitler",
            Genre = "autobiography",
            Available = true,
            PublishedYear = 1925
            },
             new book {
            Id = 2,
            Title = "The Plague Doctor",
            Author = "James C. Morehead",
            Genre = "poetry",
            Available = true,
            PublishedYear = 2023
            }
       };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                status = "success",
                data = books,
                message = "Books Retrieved."
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Book not Found."
                });
            }
            return Ok(new
            {
                status = "success",
                data = book,
                message = "Book Retrieved."
            });
        }

        [HttpPost]
        public IActionResult Create([FromBody] book newBook)
        {

            newBook.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
            books.Add(newBook);


            return CreatedAtAction(nameof(GetbyId),
                new { id = newBook.Id },
                new
                {
                    status = "Success",
                    data = newBook,
                    message = "Book Created."
                });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] book updateBook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Book not Found."
                });
            }

         
            book.Title = updateBook.Title;
            book.Author = updateBook.Author;
            book.Genre = updateBook.Genre;
            book.Available = updateBook.Available;
            book.PublishedYear = updateBook.PublishedYear;

            return Ok(new
            {
                status = "success",
                data = book,
                message = "Book Updated."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Book not Found."
                });
            }
            books.Remove(book);
            return Ok(new
            {
                status = "success",
                data = (object?)null,
                message = "Book Deleted Successfully."
            });
        }
    }
}