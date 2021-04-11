using System;
using System.Collections.Generic;

namespace LibraryChallengeCore
{
    public interface ILibraryBook
    {
        Guid BookId { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        LibraryBookCategory Category { get; set; }
        string Isbn { get; set; }
        DateTime PublishedDate { get; set; }
        CheckoutResult Checkout();
        string LentToCustomerId { get; set; }
        DateTime? DueDate { get; set; }
    }

    public class ILibraryComp : IComparer<ILibraryBook>
    {
        public int Compare(ILibraryBook x, ILibraryBook y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }
}
