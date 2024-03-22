using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers.INVENTORY.FMA
{
    public class INFO_FMV_STK
    {
        Entities _db;
        public INFO_FMV_STK()
        {
            _db = Entities.CreateEntities();
        }

        public async Task<List<View_INFO_FMV_STK>> getAll()
        {
            return await _db.View_INFO_FMV_STK
                .Where(x => x.CATEGORY == "T_INFO_FMV_STK")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<View_INFO_FMV_STK> getByID(int _idPart)
        {
            return await _db.View_INFO_FMV_STK.FirstOrDefaultAsync(x => x.CATEGORY == "T_INFO_FMV_STK" && x.IDFMVSTK == _idPart);
        }

        public async Task Add(T_INFO_FMV_STK _part)
        {
            try
            {
                _db.T_INFO_FMV_STK.Add(_part);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Error [{0}] : {1}", _part.IDFMVSTK, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Error [{0}] : {1}", _part.IDFMVSTK, ex.StackTrace);
            }
        }

        public async Task AddRange(List<T_INFO_FMV_STK> _lstPart)
        {
            try
            {
                _db.T_INFO_FMV_STK.AddRange(_lstPart);
                await _db.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part FMV Error Entity: {0}, Property: {1}, Error: {2}", entityValidationErrors.Entry.Entity.GetType().Name, validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part FMV Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part FMV Error : {0}", ex.StackTrace);
            }
        }

        public async Task Update(T_INFO_FMV_STK _part)
        {
            var result = await _db.T_INFO_FMV_STK.FirstOrDefaultAsync(x => x.IDFMVSTK == _part.IDFMVSTK);
            result.MCTYPE = _part.MCTYPE;
            result.STATUS = _part.STATUS;
            result.PARTNO = _part.PARTNO;
            result.DESCRIPTION = _part.DESCRIPTION;
            result.RATING = _part.RATING;
            result.SERIALNO = _part.SERIALNO;
            result.BALANCE = _part.BALANCE;
            result.UNIT_COST = _part.UNIT_COST;
            result.REMARK = _part.REMARK;
            result.UPDATE_DATE = _part.UPDATE_DATE;
            result.UPDATE_BY = _part.UPDATE_BY;
            result.READY = _part.READY;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Sale Error [{0}] : {1}", _part.IDFMVSTK, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Sale Error [{0}] : {1}", _part.IDFMVSTK, ex.StackTrace);
            }
        }

        public async Task Delete(int _idPart)
        {
            var data = await _db.T_INFO_FMV_STK.FirstOrDefaultAsync(x => x.IDFMVSTK == _idPart);
            try
            {
                _db.T_INFO_FMV_STK.Remove(data);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Error [{0}] : {1}", _idPart, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Error [{0}] : {1}", _idPart, ex.StackTrace);
            }
        }
    }
}
