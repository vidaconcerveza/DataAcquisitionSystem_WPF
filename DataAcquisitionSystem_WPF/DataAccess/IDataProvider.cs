using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem_WPF.DataAccess
{
    public interface IDataProvider<T>
    {
        Task<T> GetById(int id);
        Task Change(T newEntity);
        Task Add(T entity);
        Task Remove(int id);
        Task<IEnumerable<T>> GetAll();
        Task SubmitChanges();

    }
}
