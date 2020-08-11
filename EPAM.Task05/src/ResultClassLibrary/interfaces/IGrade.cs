using System;
using System.Collections.Generic;
using System.Text;

namespace ResultClassLibrary.Interfaces
{
    public interface IGrade<T>
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public T Grade { get; set; }
    }
}
