using System;
using System.Collections.Generic;
using System.Text;

namespace ProductClassLibrary
{
    public class Notepad : Product
    {
        public override string Name { get; set; }
        public override double Price { get; set; }
        public int NumberOfPages { get; set; }

        public static Notepad operator +(Notepad notepad1, Notepad notepad2)
        {
            if (notepad1 == null || notepad2 == null)
                throw new ArgumentNullException();

            return new Notepad
            {
                Name = notepad1.Name + "-" + notepad2.Name,
                Price = (notepad1.Price + notepad2.Price) / 2,
                NumberOfPages = notepad1.NumberOfPages + notepad2.NumberOfPages,
            };
        }
    }
}
