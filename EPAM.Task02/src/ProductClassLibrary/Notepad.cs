using System;

namespace ProductClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="notepad"]/Notepad/*'/>
    public class Notepad : Product
    {
        /// <include file='docs.xml' path='docs/members[@name="notepad"]/Name/*'/>
        public override string Name { get; set; }

        private decimal _price;
        /// <include file='docs.xml' path='docs/members[@name="notepad"]/Price/*'/>
        public override decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Price should be positive.");
                _price = value;
            }
        }

        private int _numberOfPages;
        /// <include file='docs.xml' path='docs/members[@name="notepad"]/NumberOfPages/*'/>
        public int NumberOfPages
        {
            get => _numberOfPages;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Number of pages should be positive.");
                _numberOfPages = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/AddOperator/*'/>
        public static Notepad operator +(Notepad notepad1, Notepad notepad2)
            => new Notepad
            {
                Name = notepad1.Name + "-" + notepad2.Name,
                Price = (notepad1.Price + notepad2.Price) / 2,
                NumberOfPages = notepad1.NumberOfPages + notepad2.NumberOfPages,
            };

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/ConvertBookToNotepad/*'/>
        public static explicit operator Notepad(Book book)
            => new Notepad
            {
                Name = book.Name,
                Price = book.Price,
                NumberOfPages = book.NumberOfPages,
            };

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/ConvertLaptopToNotepad/*'/>
        public static explicit operator Notepad(Laptop laptop)
            => new Notepad
            {
                Name = laptop.Name,
                Price = laptop.Price,
                NumberOfPages = 0,
            };

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/ConvertNotepadToInt32/*'/>
        public static explicit operator int(Notepad notepad)
            => Convert.ToInt32(notepad.Price) * 100;

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/ConvertNotepadToDouble/*'/>
        public static explicit operator decimal(Notepad notepad)
            => notepad.Price;

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            return obj is Notepad notepad &&
                   notepad.Name == Name &&
                   notepad.Price == Price &&
                   notepad.NumberOfPages == NumberOfPages;
        }

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/GetHashCode/*'/>
        public override int GetHashCode()
            => HashCode.Combine(Name, Price, NumberOfPages);
    }
}
