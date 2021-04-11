using System;
using System.Collections.Generic;
using System.Linq;
using LibraryChallengeCore.Data;

namespace LibraryChallengeCore
{
    public class LibraryService
    {
        private readonly IList<ILibraryBook> _books;

        public LibraryService()
        {
            _books = new LibraryData().Books;
        }

        public IList<ILibraryBook> AllBooks()
        {
            return _books;
        }

        public IList<CategoryCatalogueInfoDto> AllBooksSortedByCategory()
        {
            var booksSortedByCategories = new Dictionary<LibraryBookCategory, List<ILibraryBook>>();

            foreach (var book in _books)
            {
                if (!booksSortedByCategories.ContainsKey(book.Category))
                {
                    booksSortedByCategories.Add(book.Category, new List<ILibraryBook> { book });
                } else
                {
                    if (booksSortedByCategories.TryGetValue(book.Category, out var bookInCategory))
                    {
                        bookInCategory.Add(book);
                    }
                }
            }

            var fineCalculator = new LibraryBookFineCalculator();

            return booksSortedByCategories.Select(entry => {
                entry.Value.Sort(new ILibraryComp());
                double totalFine = (double) fineCalculator.CalculateTotalFine(DateTime.Today, entry.Value) / 100;
                
                return
                    new CategoryCatalogueInfoDto
                    {
                        Category = entry.Key.ToString(),
                        Count = entry.Value.Count(),
                        FineTotal = totalFine,
                        Books = entry.Value
                    };
            }).ToList();

        }

        public IEnumerable<ILibraryBook> AllBooks(LibraryBookCategory category)
        {
            return _books.Where(lb => lb.Category == category);
        }

        public ILibraryBook Book(Guid bookId)
        {
            return _books.FirstOrDefault(b => b.BookId == bookId);
        }
    }
}
