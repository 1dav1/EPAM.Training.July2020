using System;

namespace ProductClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="product"]/Product/*'/>
    public abstract class Product
    {
        /// <include file='docs.xml' path='docs/members[@name="product"]/Name/*'/>
        public abstract string Name { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="product"]/Price/*'/>
        public abstract decimal Price { get; set; }

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();
    }
}
