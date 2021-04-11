using LibraryChallengeCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LibraryChallengeWeb2.Controllers
{
    [ApiController]
    [Route("api")]
    public class LibraryBooksController : ControllerBase
    {
        private readonly LibraryService _libraryService;

        public LibraryBooksController(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        [Route("library/allBooksByCategory")]
        public IActionResult GetAllLibraryBookByCategory()
        {
            return Ok(_libraryService.AllBooksSortedByCategory());
        }

        [HttpGet]
        [Route("library/books")]
        public IActionResult GetAllLibraryBooks()
        {
            return Ok(_libraryService.AllBooks());
        }

        [HttpGet]
        [Route("library/books/{category}")]
        public IEnumerable<ILibraryBook> GetAllLibraryBooksForACategory(LibraryBookCategory category)
        {
            return _libraryService.AllBooks(category);
        }

        [HttpPost]
        [Route("library/books/{bookid}/checkout")]
        public IActionResult CheckoutALibraryBook(Guid bookId)
        {
            ILibraryBook book = _libraryService.Book(bookId);

            string message = string.Empty;
            if (book != null)
            {
                DateTime dueDate = DateTime.Now.AddDays(30);

                CheckoutResult result = book.Checkout();

                if (result.CheckedOutResultStatus == CheckedOutResultStatus.Ok)
                {
                    return Ok(new { BookId = bookId, DueDate = dueDate });
                }
                message = result.Message;
            }

            return BadRequest(message);
        }
    }
}
