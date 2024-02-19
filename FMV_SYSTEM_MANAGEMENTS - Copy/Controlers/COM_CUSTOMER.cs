using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            _dbcontext = Entities.CreateEntities();
        }

        public async Task<List<T_COM_CUSTOMER>> getAll()
        {
            return await _dbcontext.T_COM_CUSTOMER.ToListAsync();
        }

        public async Task<T_COM_CUSTOMER> getByID(string _idcus)
        {
            return await _dbcontext.T_COM_CUSTOMER.FirstOrDefaultAsync(x => x.IDCUSTOMER == _idcus);
        }

        public async Task Add(T_COM_CUSTOMER _cus)
        {
            try
            {
                _dbcontext.T_COM_CUSTOMER.Add(_cus);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(T_COM_CUSTOMER _cus)
        {
            var data = await getByID(_cus.IDCUSTOMER);
            data.CUSTOMERNAME = _cus.CUSTOMERNAME;
            data.CONTACTPERSON = _cus.CONTACTPERSON;
            data.PHONE = _cus.PHONE;
            data.EMAIL = _cus.EMAIL;
            data.UPDATE_DATE = _cus.UPDATE_DATE;
            data.UPDATE_BY = _cus.UPDATE_BY;
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
                _dbcontext.T_COM_CUSTOMER.Remove(data);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
