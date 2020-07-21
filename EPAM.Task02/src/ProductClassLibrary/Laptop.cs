using System;

namespace ProductClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="laptop"]/Laptop/*'/>
    public class Laptop : Product
    {
        /// <include file='docs.xml' path='docs/members[@name="laptop"]/Name/*'/>
        public override string Name { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/Price/*'/>
        public override decimal Price { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/CPUFrequancy/*'/>
        public double CPUFrequancy { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/AddOperator/*'/>
        public static Laptop operator +(Laptop laptop1, Laptop laptop2)
        => new Laptop
            {
                Name = laptop1.Name + "-" + laptop2.Name,
                Price = (laptop1.Price + laptop2.Price) / 2,
                CPUFrequancy = (laptop1.CPUFrequancy + laptop2.CPUFrequancy) / 2,
            };

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/ConvertLaptopToBook/*'/>
        //public static explicit operator Book(Laptop laptop)
        //    => new Book
        //    {
        //        Name = laptop.Name,
        //        Price = laptop.Price,
        //        Author = "n/a",
        //        NumberOfPages = 0,
        //    };

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/ConvertLaptopToNotepad/*'/>
        public static explicit operator Notepad(Laptop laptop)
            => new Notepad
            {
                Name = laptop.Name,
                Price = laptop.Price,
                NumberOfPages = 0,
            };

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/ConvertLaptopToInt32/*'/>
        public static explicit operator int(Laptop laptop)
            => Convert.ToInt32(laptop.Price) * 100;

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/ConvertLaptopToDouble/*'/>
        public static explicit operator decimal(Laptop laptop)
            => laptop.Price;

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
