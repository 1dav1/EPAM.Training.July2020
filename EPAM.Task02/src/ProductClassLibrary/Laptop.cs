using System;

namespace ProductClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="laptop"]/Laptop/*'/>
    public class Laptop : Product
    {
        private const int KOPEK = 100;

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/Name/*'/>
        public override string Name { get; set; }

        private decimal _price;
        /// <include file='docs.xml' path='docs/members[@name="laptop"]/Price/*'/>
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

        double _cpuFrequancy;
        /// <include file='docs.xml' path='docs/members[@name="laptop"]/CPUFrequancy/*'/>
        public double CPUFrequancy 
        { 
            get => _cpuFrequancy; 
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("CPU frequancy should be positive.");
                _cpuFrequancy = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/AddOperator/*'/>
        public static Laptop operator +(Laptop laptop1, Laptop laptop2)
        => new Laptop
            {
                Name = laptop1.Name + "-" + laptop2.Name,
                Price = (laptop1.Price + laptop2.Price) / 2,
                CPUFrequancy = (laptop1.CPUFrequancy + laptop2.CPUFrequancy) / 2,
            };

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/ConvertBookToLaptop/*'/>
        public static explicit operator Laptop(Book book)
            => new Laptop
            {
                Name = book.Name,
                Price = book.Price,
                CPUFrequancy = 0,
            };

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/ConvertNotepadToLaptop/*'/>
        public static explicit operator Laptop(Notepad notepad)
            => new Laptop
            {
                Name = notepad.Name,
                Price = notepad.Price,
                CPUFrequancy = 0,
            };

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/ConvertLaptopToInt32/*'/>
        public static explicit operator int(Laptop laptop)
            => Convert.ToInt32(laptop.Price) * KOPEK;

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/ConvertLaptopToDouble/*'/>
        public static explicit operator decimal(Laptop laptop)
            => laptop.Price;

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            return obj is Laptop laptop &&
                laptop.Name == Name &&
                laptop.Price == Price &&
                laptop.CPUFrequancy == CPUFrequancy;
        }

        /// <include file='docs.xml' path='docs/members[@name="laptop"]/GetHashCode/*'/>
        public override int GetHashCode()
            => HashCode.Combine(Name, Price, CPUFrequancy);
    }
}
