using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENT.Controlers
{
    public class COM_STAFF
    {
        Entities _dbcontext;
        public COM_STAFF()
        {
            _dbcontext = Entities.CreateEntities();
        }

        public async Task<List<T_COM_STAFF>> getAll()
        {
            return await _dbcontext.T_COM_STAFF.ToListAsync();
        }

        public async Task<T_COM_STAFF> getByID(int _idstaff)
        {
            return await _dbcontext.T_COM_STAFF.FirstOrDefaultAsync(x => x.IDSTAFF == _idstaff);
        }

        public async Task Add(T_COM_STAFF _staff)
        {
            try
            {
                _dbcontext.T_COM_STAFF.Add(_staff);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(T_COM_STAFF _staff)
        {
            var data = await getByID(_staff.IDSTAFF);
            data.STAFFNAME = _staff.STAFFNAME;
            data.DEPARTMENT = _staff.DEPARTMENT;
            data.POSITION = _staff.POSITION;
            data.CCCD = _staff.CCCD;
            data.PHONE = _staff.PHONE;
            data.EMAIL = _staff.EMAIL;
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            var data = await getByID(id);
            try
            {
                _dbcontext.T_COM_STAFF.Remove(data);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
