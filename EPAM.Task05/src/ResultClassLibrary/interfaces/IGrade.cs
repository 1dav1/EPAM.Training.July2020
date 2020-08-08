using System;
using System.Collections.Generic;
using System.Text;

namespace ResultClassLibrary.interfaces
{
    public interface IGrade<C>
    {
        public string Name { get; set; }
        public string Test { get; set; }
        public C Grade { get; set; }
    }
}
