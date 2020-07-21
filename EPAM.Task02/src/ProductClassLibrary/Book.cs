using System;

namespace ProductClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="book"]/Book/*'/>
    public class Book : Product
    {
        /// <include file='docs.xml' path='docs/members[@name="book"]/Name/*'/>
        public override string Name { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="book"]/Price/*'/>
        public override double Price { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="book"]/Author/*'/>
        public string Author { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="book"]/NumberOfPages/*'/>
        public int NumberOfPages { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="book"]/AddBookBook/*'/>
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

        public static explicit operator int(Book book)
            => Convert.ToInt32(book.Price);

        public static explicit operator double(Book book)
            => book.Price;
    }
}
