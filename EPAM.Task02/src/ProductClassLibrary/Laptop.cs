using System;
using System.Collections.Generic;
using System.Text;

namespace ProductClassLibrary
{
    public class Laptop : Product
    {
        public override string Name { get; set; }
        public override double Price { get; set; }
        public string GPU { get; set; }

        public static Laptop operator +(Laptop laptop1, Laptop laptop2)
        {
            if (laptop1 == null || laptop2 == null)
                throw new ArgumentNullException();

            return new Laptop
            {
                Name = laptop1.Name + "-" + laptop2.Name,
                Price = (laptop1.Price + laptop2.Price) / 2,
                GPU = laptop1.GPU + "-" + laptop2.GPU,
            };
        }

        public static explicit operator Book(Laptop laptop)
            => new Book
            {
                Name = laptop.Name,
                Price = laptop.Price,
                Author = "n/a",
                NumberOfPages = 0,
            };

        public static explicit operator Notepad(Laptop laptop)
            => new Notepad
            {
                Name = laptop.Name,
                Price = laptop.Price,
                NumberOfPages = 0,
            };

    }
}
