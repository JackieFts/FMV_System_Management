using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers.INVENTORY.FMA
{
    public class INFO_FMV_FORSALE
    {
        Entities _db;
        public INFO_FMV_FORSALE()
        {
            _db = Entities.CreateEntities();
        }

        public async Task<List<View_INFO_FMV_FORSALE>> getAll()
        {
            return await _db.View_INFO_FMV_FORSALE
                .Where(x => x.CATEGORY == "T_INFO_FMV_FORSALE")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<View_INFO_FMV_FORSALE> getByID(int _idPart)
        {
            return await _db.View_INFO_FMV_FORSALE.FirstOrDefaultAsync(x => x.CATEGORY == "T_INFO_FMV_FORSALE" && x.IDFMVSALE == _idPart);
        }

        public async Task Add(T_INFO_FMV_FORSALE _part)
        {
            try
            {
                _db.T_INFO_FMV_FORSALE.Add(_part);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Sale Error [{0}] : {1}", _part.IDFMVSALE, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Sale Error [{0}] : {1}", _part.IDFMVSALE, ex.StackTrace);
            }
        }

        public async Task AddRange(List<T_INFO_FMV_FORSALE> _lstPart)
        {
            try
            {
                _db.T_INFO_FMV_FORSALE.AddRange(_lstPart);
                await _db.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part FMV Sale Error Entity: {0}, Property: {1}, Error: {2}", entityValidationErrors.Entry.Entity.GetType().Name, validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part FMV Sale Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part FMV Sale Error : {0}", ex.StackTrace);
            }
        }

        public async Task Update(T_INFO_FMV_FORSALE _part)
        {
            var result = await _db.T_INFO_FMV_FORSALE.FirstOrDefaultAsync(x => x.IDFMVSALE == _part.IDFMVSALE);
            result.MCTYPE = _part.MCTYPE;
            result.STATUS = _part.STATUS;
            result.PARTNO = _part.PARTNO;
            result.DESCRIPTION = _part.DESCRIPTION;
            result.RATING = _part.RATING;
            result.SERIALNO = _part.SERIALNO;
            result.ORIGIN = _part.ORIGIN;
            result.BALANCE = _part.BALANCE;
            result.UNIT_COST_JPY = _part.UNIT_COST_JPY;
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
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Sale Error [{0}] : {1}", _part.IDFMVSALE, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Sale Error [{0}] : {1}", _part.IDFMVSALE, ex.StackTrace);
            }
        }

        public async Task Delete(int _idPart)
        {
            var data = await _db.T_INFO_FMV_FORSALE.FirstOrDefaultAsync(x => x.IDFMVSALE == _idPart);
            try
            {
                _db.T_INFO_FMV_FORSALE.Remove(data);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Sale Error [{0}] : {1}", _idPart, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMV Sale Error [{0}] : {1}", _idPart, ex.StackTrace);
            }
        }
    }
}
