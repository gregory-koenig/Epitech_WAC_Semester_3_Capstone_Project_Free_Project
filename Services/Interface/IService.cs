using System.Collections.Generic;
using Ccsrb.Entities;

namespace Ccsrb.Services.Interface
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Create(T c);
        T Update(T c);
        void Delete(int id);
    }
}