using System;

namespace ProductClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="product"]/Product/*'/>
    public abstract class Product
    {
        public abstract string Name { get; set; }
        public abstract double Price { get; set; }
    }
}
