using System;

namespace ProductClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="notepad"]/Notepad/*'/>
    public class Notepad : Product
    {
        /// <include file='docs.xml' path='docs/members[@name="notepad"]/Name/*'/>
        public override string Name { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/Price/*'/>
        public override decimal Price { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/NumberOfPages/*'/>
        public int NumberOfPages { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/AddOperator/*'/>
        public static Notepad operator +(Notepad notepad1, Notepad notepad2)
            => new Notepad
            {
                Name = notepad1.Name + "-" + notepad2.Name,
                Price = (notepad1.Price + notepad2.Price) / 2,
                NumberOfPages = notepad1.NumberOfPages + notepad2.NumberOfPages,
            };

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/ConvertNotepadToBook/*'/>
        public static explicit operator Book(Notepad notepad)
            => new Book
            {
                Name = notepad.Name,
                Price = notepad.Price,
                Author = "n/a",
                NumberOfPages = notepad.NumberOfPages,
            };

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/ConvertNotepadToLaptop/*'/>
        public static explicit operator Laptop(Notepad notepad)
            => new Laptop
            {
                Name = notepad.Name,
                Price = notepad.Price,
                CPUFrequancy = 0,
            };

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/ConvertNotepadToInt32/*'/>
        public static explicit operator int(Notepad notepad)
            => Convert.ToInt32(notepad.Price) * 100;

        /// <include file='docs.xml' path='docs/members[@name="notepad"]/ConvertNotepadToDouble/*'/>
        public static explicit operator decimal(Notepad notepad)
            => notepad.Price;

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

    }
}
