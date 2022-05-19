using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library
    {
        private List<Book> Books;

        public Library(params Book[] books)
        {
            Books = new List<Book>(books);
        }
    }
}
