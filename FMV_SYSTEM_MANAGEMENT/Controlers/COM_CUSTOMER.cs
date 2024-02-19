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
    public class COM_CUSTOMER
    {
        Entities _dbcontext;
        public COM_CUSTOMER()
        {
            _dbcontext = new Entities();
        }

        public async Task<List<TComCustomer>> getAll()
        {
            return await _dbcontext.TComCustomers.ToListAsync();
        }

        public async Task<TComCustomer> getByID(string _idcus)
        {
            return await _dbcontext.TComCustomers.FirstOrDefaultAsync(x => x.Idcustomer == _idcus);
        }

        public async Task Add(TComCustomer _cus)
        {
            try
            {
                _dbcontext.TComCustomers.Add(_cus);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(TComCustomer _cus)
        {
            var data = await getByID(_cus.Idcustomer);
            data.Customername = _cus.Customername;
            data.Contactperson = _cus.Contactperson;
            data.Phone = _cus.Phone;
            data.Email = _cus.Email;
            data.UpdateDate = _cus.UpdateDate;
            data.UpdateBy = _cus.UpdateBy;
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(string id)
        {
            var data = await getByID(id);
            try
            {
                _dbcontext.TComCustomers.Remove(data);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
