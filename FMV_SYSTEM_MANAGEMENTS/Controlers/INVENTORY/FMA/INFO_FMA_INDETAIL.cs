using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers.INVENTORY.FMA
{
    public class INFO_FMA_INDETAIL
    {
        Entities _db;
        public INFO_FMA_INDETAIL()
        {
            _db = Entities.CreateEntities();
        }

        public async Task Add(T_INFO_FMA_INDETAIL _part)
        {
            try
            {
                _db.T_INFO_FMA_INDETAIL.Add(_part);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMA Error [{0}] [{1}]: {2}", _part.IDFMA, _part.CATEGORY, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMA Error [{0}] [{1}]: {2}", _part.IDFMA, _part.CATEGORY, ex.StackTrace);
            }
        }

        public async Task AddRange(List<T_INFO_FMA_INDETAIL> _lstPart)
        {
            try
            {
                _db.T_INFO_FMA_INDETAIL.AddRange(_lstPart);
                await _db.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part FMA Error Entity: {0}, Property: {1}, Error: {2}", entityValidationErrors.Entry.Entity.GetType().Name, validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part FMA Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part FMA Error : {0}", ex.StackTrace);
            }
        }

        public async Task Update(T_INFO_FMA_INDETAIL _part)
        {
            var result = await _db.T_INFO_FMA_INDETAIL.FirstOrDefaultAsync(x => x.IDFMA == _part.IDFMA && x.CATEGORY == _part.CATEGORY);
            result.QTY = _part.QTY;
            result.QTY_UNIT = _part.QTY_UNIT;
            result.DATE = _part.DATE;
            result.LOCATION_SHELFNO = _part.LOCATION_SHELFNO;
            result.BOXNO = _part.BOXNO;
            result.FMVTJ_CODE = _part.FMVTJ_CODE;
            result.RACK = _part.RACK;
            result.REMARK = _part.REMARK;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update Part FMA Error [{0}] [{1}]: {2}", _part.IDFMA, _part.CATEGORY, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update Part FMA Error [{0}] [{1}]: {2}", _part.IDFMA, _part.CATEGORY, ex.StackTrace);
            }
        }

        public async Task Delete(int _idFMA, string _cate)
        {
            var data = await _db.T_INFO_FMA_INDETAIL.FirstOrDefaultAsync(x => x.IDFMA == _idFMA && x.CATEGORY == _cate);
            try
            {
                _db.T_INFO_FMA_INDETAIL.Remove(data);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Delete Part FMA Error [{0}] [{1}]: {2}", _idFMA, _cate, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Delete Part FMA Error [{0}] [{1}]: {2}", _idFMA, _cate, ex.StackTrace);
            }
        }
    }
}
