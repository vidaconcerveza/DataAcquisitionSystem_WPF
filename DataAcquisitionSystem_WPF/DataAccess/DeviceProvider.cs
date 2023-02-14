using DataAcquisitionSystem_WPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem_WPF.DataAccess
{
    public class DeviceProvider : IDataProvider<Device>
    {
        private readonly LocalDbContext _db;

        public DeviceProvider(LocalDbContext db)
        {
            _db = db;
        }
        public async Task Add(Device entity)
        {
            var result = await _db.Devices.AddAsync(entity);
        }

        public async Task Change(Device newEntity)
        {
            var result = _db.Devices.Update(newEntity);
            await SubmitChanges();

        }

        public async Task<IEnumerable<Device>> GetAll()
        {
            var result = await _db.Devices.ToListAsync();
            return result;
        }

        public async Task<Device> GetById(int id)
        {
            var result = await _db.Devices.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task Remove(int id)
        {
            var entity = await _db.Devices.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(entity!= null)
            {
                var result = _db.Devices.Remove(entity);
                await SubmitChanges();
            }
        }

        public async Task SubmitChanges()
        {
            await _db.SaveChangesAsync();
        }
    }

}
