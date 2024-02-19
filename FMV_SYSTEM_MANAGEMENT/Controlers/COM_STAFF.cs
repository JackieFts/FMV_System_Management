using FMV_SYSTEM_MANAGEMENT.Models;
using FMV_SYSTEM_MANAGEMENT.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            _dbcontext = new Entities();
        }

        public async Task<List<TComStaff>> getAll()
        {
            return await _dbcontext.TComStaffs.ToListAsync();
        }

        public async Task<TComStaff> getByID(int _idstaff)
        {
            return await _dbcontext.TComStaffs.FirstOrDefaultAsync(x => x.Idstaff == _idstaff);
        }

        public async Task Add(TComStaff _staff)
        {
            try
            {
                _dbcontext.TComStaffs.Add(_staff);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(TComStaff _staff)
        {
            var data = await getByID(_staff.Idstaff);
            data.Staffname = _staff.Staffname;
            data.Department = _staff.Department;
            data.Position = _staff.Position;
            data.CCCD = _staff.CCCD;
            data.Phone = _staff.Phone;
            data.Email = _staff.Email;
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
                _dbcontext.TComStaffs.Remove(data);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
