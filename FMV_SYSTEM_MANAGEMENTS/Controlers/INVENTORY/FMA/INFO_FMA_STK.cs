using FMV_SYSTEM_MANAGEMENTS.Models;
using FMV_SYSTEM_MANAGEMENTS.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers.INVENTORY.FMA
{
    public class INFO_FMA_STK
    {
        Entities _db;
        public INFO_FMA_STK()
        {
            _db = Entities.CreateEntities();
        }

        //public async Task<List<OBJ_T_INFO_FMA_STK>> getAll()
        //{
        //    var result = await _db.T_INFO_FMA_STK
        //        .Join(
        //            _db.T_INFO_FMA_INDETAIL,
        //            a => a.IDFMASTK,
        //            b => b.IDFMA,
        //            (a, b) => new { T_INFO_FMA_STK = a, T_INFO_FMA_INDETAIL = b }
        //        )
        //        .Join(
        //            _db.T_INFO_FMA_OUTDETAIL,
        //            ab => ab.T_INFO_FMA_STK.IDFMASTK,
        //            c => c.IDFMA,
        //            (ab, c) => new OBJ_T_INFO_FMA_STK
        //            {
        //                IDFMASTK = ab.T_INFO_FMA_STK.IDFMASTK,
        //                MCTYPE = ab.T_INFO_FMA_STK.MCTYPE,
        //                STATUS = ab.T_INFO_FMA_STK.STATUS,
        //                PRODCODE = ab.T_INFO_FMA_STK.PRODCODE,
        //                DESCRIPTION = ab.T_INFO_FMA_STK.DESCRIPTION,
        //                RATING = ab.T_INFO_FMA_STK.RATING,
        //                SERIAL = ab.T_INFO_FMA_STK.SERIAL,
        //                BALANCE = ab.T_INFO_FMA_STK.BALANCE,
        //                UNIT_COST_SGD = ab.T_INFO_FMA_STK.UNIT_COST_SGD,
        //                REMARK = ab.T_INFO_FMA_STK.REMARK,
        //                DIFF = ab.T_INFO_FMA_STK.DIFF,
        //                CATEGORY = ab.T_INFO_FMA_INDETAIL.CATEGORY,
        //                QTY = ab.T_INFO_FMA_INDETAIL.QTY,
        //                QTY_UNIT = ab.T_INFO_FMA_INDETAIL.QTY_UNIT,
        //                DATE = ab.T_INFO_FMA_INDETAIL.DATE,
        //                LOCATION_SHELFNO = ab.T_INFO_FMA_INDETAIL.LOCATION_SHELFNO,
        //                BOXNO = ab.T_INFO_FMA_INDETAIL.BOXNO,
        //                FMVTJ_CODE = ab.T_INFO_FMA_INDETAIL.FMVTJ_CODE,
        //                RACK = ab.T_INFO_FMA_INDETAIL.RACK,
        //                IN_REMARK = ab.T_INFO_FMA_INDETAIL.REMARK,
        //                OUT_QTY = c.QTY,
        //                OUT_DATE = c.DATE,
        //                OUT_RACK = c.RACK,
        //                HISTORY = c.HISTORY,
        //                OUT_REMARK = c.REMARK
        //            }
        //        )
        //        .Where(x => x.CATEGORY == "T_INFO_FMA_STK")
        //        .AsNoTracking()
        //        .ToListAsync();
        //    return result;
        //}

        public async Task<List<View_INFO_FMA_STK>> getAll()
        {
            return await _db.View_INFO_FMA_STK
                .Where(x => x.CATEGORY == "T_INFO_FMA_STK")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<View_INFO_FMA_STK> getByID(int _idPart)
        {
            return await _db.View_INFO_FMA_STK.FirstOrDefaultAsync(x => x.CATEGORY == "T_INFO_FMA_STK" && x.IDFMASTK == _idPart);
        }

        public async Task Add(T_INFO_FMA_STK _part)
        {
            try
            {
                _db.T_INFO_FMA_STK.Add(_part);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMA Error [{0}] : {1}", _part.IDFMASTK, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMA Error [{0}] : {1}", _part.IDFMASTK, ex.StackTrace);
            }
        }

        public async Task AddRange(List<T_INFO_FMA_STK> _lstPart)
        {
            try
            {
                _db.T_INFO_FMA_STK.AddRange(_lstPart);
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

        public async Task Update(T_INFO_FMA_STK _part)
        {
            var result = await _db.T_INFO_FMA_STK.FirstOrDefaultAsync(x => x.IDFMASTK == _part.IDFMASTK);
            result.MCTYPE = _part.MCTYPE;
            result.STATUS = _part.STATUS;
            result.PRODCODE = _part.PRODCODE;
            result.DESCRIPTION = _part.DESCRIPTION;
            result.RATING = _part.RATING;
            result.SERIAL = _part.SERIAL;
            result.BALANCE = _part.BALANCE;
            result.UNIT_COST_SGD = _part.UNIT_COST_SGD;
            result.REMARK = _part.REMARK;
            result.DIFF = _part.DIFF;
            result.UPDATE_DATE = _part.UPDATE_DATE;
            result.UPDATE_BY = _part.UPDATE_BY;
            result.READY = _part.READY;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMA Error [{0}] : {1}", _part.IDFMASTK, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMA Error [{0}] : {1}", _part.IDFMASTK, ex.StackTrace);
            }
        }

        public async Task Delete(int _idPart)
        {
            var data = await _db.T_INFO_FMA_STK.FirstOrDefaultAsync(x => x.IDFMASTK == _idPart);
            try
            {
                _db.T_INFO_FMA_STK.Remove(data);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMA Error [{0}] : {1}", _idPart, ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part FMA Error [{0}] : {1}", _idPart, ex.StackTrace);
            }
        }
    }
}
