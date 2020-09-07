using System.Collections.Generic;

namespace SessionClassLibrary.Tests
{
    public interface IMockRepository<T> where T : class, new()
    {
        public IEnumerable<T> entity { get; set; }
        public IEnumerable<T> GetAll();

        public T GetById(int id);
    }
}
