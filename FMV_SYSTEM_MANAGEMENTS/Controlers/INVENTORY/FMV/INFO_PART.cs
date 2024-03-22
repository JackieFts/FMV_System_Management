using FMV_SYSTEM_MANAGEMENTS.Models;
using FMV_SYSTEM_MANAGEMENTS.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers
{
    public class INFO_PART
    {
        Entities _db;
        public INFO_PART()
        {
            _db = Entities.CreateEntities();
        }

        private static readonly Expression<Func<T_INFO_PART, OBJ_T_INFO_PART>> ProjectionExpression = e => new OBJ_T_INFO_PART
        {
            IDPART = e.IDPART,
            QRCODE = e.QRCODE,
            NAME = e.NAME,
            DESCRIPTION = e.DESCRIPTION,
            PARTNUMBER = e.PARTNUMBER,
            RANK = e.RANK,
            FIXED_ASSET_NO = e.FIXED_ASSET_NO,
            QTY = e.QTY,
            BALANCE = e.BALANCE,
            PO_RQ = e.PO_RQ,
            QUOTATION = e.QUOTATION,
            REMARK = e.REMARK,
            LOCATION = e.LOCATION,
            IDSTAFF = e.IDSTAFF,
            IDCUSTOMER = e.IDCUSTOMER,
            STATUS = e.STATUS,
        };

        // Use the compiled expression in the query
        public async Task<List<OBJ_T_INFO_PART>> getAll()
        {
            return await _db.T_INFO_PART
                .Select(ProjectionExpression)
                .AsNoTracking()
                .ToListAsync();
        }

        //public async Task<List<T_INFO_PART>> getAll()
        //{
        //    return await _db.T_INFO_PART.ToListAsync();
        //}

        public async Task<T_INFO_PART> getByID(int _idpart)
        {
            return await _db.T_INFO_PART.FirstOrDefaultAsync(x => x.IDPART == _idpart);
        }

        public async Task<T_INFO_PART> getJigbyQRCode(string _QRCode)
        {
            return await _db.T_INFO_PART.FirstOrDefaultAsync(x => x.QRCODE == _QRCode && x.BALANCE > 0);
        }

        public async Task<int> getBalancebyID(int _idpart)
        {
            var data = await _db.T_INFO_PART.FirstOrDefaultAsync(x => x.IDPART == _idpart);
            return int.Parse(data.BALANCE.ToString());
        }

        public async Task<bool> checkDuplicate(string _name, string _des, string _partnumber)
        {
            var data = await _db.T_INFO_PART.Where(x => x.NAME == _name && x.DESCRIPTION == _des && x.PARTNUMBER == _partnumber).ToListAsync();
            if (data.Count > 0)
                return true;
            return false;
        }

        public async Task Add(T_INFO_PART _part)
        {
            try
            {
                _db.T_INFO_PART.Add( _part );
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Part Error : {0}", ex.StackTrace);
            }
        }

        public async Task AddRange (List<T_INFO_PART> _lstPart)
        {
            try
            {
                _db.T_INFO_PART.AddRange(_lstPart);
                await _db.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part Error Entity: {0}, Property: {1}, Error: {2}", entityValidationErrors.Entry.Entity.GetType().Name, validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Multi Part Error : {0}", ex.StackTrace);
            }
        }

        public async Task Update(T_INFO_PART _part)
        {
            var result = await getByID( _part.IDPART);
            result.NAME = _part.NAME;
            result.DESCRIPTION = _part.DESCRIPTION;
            result.PARTNUMBER = _part.PARTNUMBER;
            result.RANK = _part.RANK;
            result.FIXED_ASSET_NO = _part.FIXED_ASSET_NO;
            result.QTY = _part.QTY;
            result.BALANCE = _part.BALANCE;
            result.PICTURE = _part.PICTURE;
            result.PO_RQ = _part.PO_RQ;
            result.QUOTATION = _part.QUOTATION;
            result.REMARK = _part.REMARK;
            result.LOCATION = _part.LOCATION;
            result.IDSTAFF = _part.IDSTAFF;
            result.IDCUSTOMER = _part.IDCUSTOMER;
            result.UPDATE_DATE = _part.UPDATE_DATE;
            result.UPDATE_BY = _part.UPDATE_BY;
            result.STATUS = _part.STATUS;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update Part Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update Part Error : {0}", ex.StackTrace);
            }
        }

        public async Task UpdateQtybyQRCode(string _QRCode, int _balance)
        {
            var result = await _db.T_INFO_PART.FirstOrDefaultAsync(x => x.QRCODE == _QRCode);
            if (result != null)
            {
                result.BALANCE = _balance;
                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task UpdateStatusbyQRCode(string _QRCode, bool _status)
        {
            var result = await _db.T_INFO_PART.FirstOrDefaultAsync(x => x.QRCODE == _QRCode);
            if (result != null)
            {
                result.STATUS = _status;
                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task Delete(int _idpart)
        {
            var data = await getByID(_idpart);
            try
            {
                _db.T_INFO_PART.Remove(data);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Delete part Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Delete part Error : {0}", ex.StackTrace);
            }
        }
    }
}
