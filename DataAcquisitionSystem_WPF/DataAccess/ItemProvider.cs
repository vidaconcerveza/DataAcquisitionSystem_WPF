using DataAcquisitionSystem_WPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem_WPF.DataAccess
{
    public class ItemProvider : IDataProvider<Item>
    {
        private readonly LocalDbContext _db;

        public ItemProvider(LocalDbContext db)
        {
            _db = db;
        }
        public async Task Add(Item entity)
        {
            var result = await _db.Items.AddAsync(entity);
        }

        public async Task Change(Item newEntity)
        {
            var result = _db.Items.Update(newEntity);
            await SubmitChanges();

        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            var result = await _db.Items.ToListAsync();
            return result;
        }

        public async Task<Item> GetById(int id)
        {
            var result = await _db.Items.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task Remove(int id)
        {
            var entity = await _db.Items.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity != null)
            {
                var result = _db.Items.Remove(entity);
                await SubmitChanges();
            }
        }

        public async Task SubmitChanges()
        {
            await _db.SaveChangesAsync();
        }
    }

}
