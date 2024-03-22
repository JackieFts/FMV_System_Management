using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers.MONTHLY
{
    public class REP_MCTYPE
    {
        Entities _db;
        public REP_MCTYPE()
        {
            _db = Entities.CreateEntities();
        }

        public async Task<List<T_REP_MCTYPE>> getAll()
        {
            return await _db.T_REP_MCTYPE.ToListAsync();
        }

        public async Task<T_REP_MCTYPE> getByID(int _idType)
        {
            return await _db.T_REP_MCTYPE.FirstOrDefaultAsync(x => x.IDMCTYPE == _idType);
        }

        public async Task Add(T_REP_MCTYPE _type)
        {
            try
            {
                _db.T_REP_MCTYPE.Add(_type);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add MCType Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add MCType Error : {0}", ex.StackTrace);
            }
        }

        public async Task AddRange(BindingList<T_REP_MCTYPE> _lstMc)
        {
            try
            {
                _db.T_REP_MCTYPE.AddRange(_lstMc);
                await _db.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi MCType Error Entity: {0}, Property: {1}, Error: {2}", entityValidationErrors.Entry.Entity.GetType().Name, validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi MCType Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi MCType Error : {0}", ex.StackTrace);
            }
        }

        public async Task Update(T_REP_MCTYPE _type)
        {
            var data = await getByID(_type.IDMCTYPE);
            data.BRAND = _type.BRAND;
            data.MCTYPE = _type.MCTYPE;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update MCType Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update MCType Error : {0}", ex.StackTrace);
            }
        }

        public async Task Delete(int id)
        {
            var data = await getByID(id);
            try
            {
                _db.T_REP_MCTYPE.Remove(data);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Delete MCType Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Delete MCType Error : {0}", ex.StackTrace);
            }
        }

        public void TrunCate()
        {
            _db.TruncateTable("T_REP_MCTYPE");
        }
    }
}
