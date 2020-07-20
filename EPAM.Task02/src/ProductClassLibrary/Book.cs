using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductClassLibrary
{
    public class Book : Product
    {
        public override string Name { get; set; }
        public override double Price { get; set; }
        public string Author { get; set; }
        public int NumberOfPages { get; set; }

        public static Book operator +(Book book1, Book book2)
        {
            if (book1 == null || book2 == null)
                throw new ArgumentNullException();

            return new Book
            {
                Name = book1.Name + "-" + book2.Name,
                Price = (book1.Price + book2.Price) / 2,
                Author = book1.Author + "-" + book2.Author,
                NumberOfPages = book1.NumberOfPages + book2.NumberOfPages,
            };
        }

        public static explicit operator Notepad(Book book)
            => new Notepad
            {
                Name = book.Name,
                Price = book.Price,
                NumberOfPages = book.NumberOfPages,
            };

        public static explicit operator Laptop(Book book)
            => new Laptop
            {
                Name = book.Name,
                Price = book.Price,
                GPU = "n/a",
            };
    }
}
