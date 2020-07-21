using System;

namespace ProductClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="book"]/Book/*'/>
    public class Book : Product
    {
        /// <include file='docs.xml' path='docs/members[@name="book"]/Name/*'/>
        public override string Name { get; set; }

        private decimal _price;
        /// <include file='docs.xml' path='docs/members[@name="book"]/Price/*'/>
        public override decimal Price
        {
            get => _price;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price should be positive.");
                _price = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="book"]/Author/*'/>
        public string Author { get; set; }

        private int _numberOfPages;

        /// <include file='docs.xml' path='docs/members[@name="book"]/NumberOfPages/*'/>
        public int NumberOfPages
        {
            get => _numberOfPages;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Number of pages should be positive.");
                _numberOfPages = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="book"]/AddOperator/*'/>
        public static Book operator +(Book book1, Book book2)
            => new Book
            {
                Name = book1.Name + "-" + book2.Name,
                Price = (book1.Price + book2.Price) / 2,
                Author = book1.Author + "-" + book2.Author,
                NumberOfPages = book1.NumberOfPages + book2.NumberOfPages,
            };


        /// <include file='docs.xml' path='docs/members[@name="book"]/ConvertNotepadToBook/*'/>
        public static explicit operator Book(Notepad notepad)
            => new Book
            {
                Name = notepad.Name,
                Price = notepad.Price,
                Author = "n/a",
                NumberOfPages = notepad.NumberOfPages,
            };

        /// <include file='docs.xml' path='docs/members[@name="book"]/ConvertLaptopToBook/*'/>
        public static explicit operator Book(Laptop laptop)
            => new Book
            {
                Name = laptop.Name,
                Price = laptop.Price,
                Author = "n/a",
                NumberOfPages = 0,
            };

        /// <include file='docs.xml' path='docs/members[@name="book"]/ConvertBookToInt32/*'/>
        public static explicit operator int(Book book)
            => Convert.ToInt32(book.Price) * 100;

        /// <include file='docs.xml' path='docs/members[@name="book"]/ConvertBookToDecimal/*'/>
        public static explicit operator decimal(Book book)
            => book.Price;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            return obj is Book book &&
                   book.Author == Author &&
                   book.Name == Name &&
                   book.Price == Price &&
                   book.NumberOfPages == NumberOfPages;
        }

        public override int GetHashCode()
            => HashCode.Combine(Name, Price, Author, NumberOfPages);
    }
}
