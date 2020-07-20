using System;

namespace ProductClassLibrary
{
    public abstract class Product
    {
        public abstract string Name { get; set; }
        public abstract double Price { get; set; }
    }
}
