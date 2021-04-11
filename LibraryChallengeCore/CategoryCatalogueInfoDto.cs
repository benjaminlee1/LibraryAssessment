using System.Collections.Generic;

namespace LibraryChallengeCore
{
    public class CategoryCatalogueInfoDto
    {
        public string Category { get; set; }
        public int Count { get; set; }
        public double FineTotal { get; set; }
        public IList<ILibraryBook> Books { get; set; }
    }
}
