using DevExpress.Data.Browsing;
using FMV_SYSTEM_MANAGEMENTS.Models;
using FMV_SYSTEM_MANAGEMENTS.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers
{
    public class INFO_JIG
    {
        Entities _db;
        public INFO_JIG()
        {
            _db = Entities.CreateEntities();
        }

        //private static readonly Func<Entities, Task<List<T_INFO_JIG>>> compiledQuery =
        //CreateCompiledQuery();

        //private static Func<Entities, Task<List<T_INFO_JIG>>> CreateCompiledQuery()
        //{
        //    Expression<Func<Entities, Task<List<T_INFO_JIG>>>> expression =
        //        context => context.T_INFO_JIG.AsNoTracking().ToListAsync();

        //    return expression.Compile();
        //}

        //private static Func<Entities, Task<List<T_INFO_JIG>>> GetTInfoJigs =
        //CompiledQuery.Compile(
        //    (Entities context) =>
        //        context.Set<T_INFO_JIG>().AsNoTracking().ToListAsync());

        //public async Task<List<T_INFO_JIG>> GetTInfoJigsAsync()
        //{
        //    return await GetTInfoJigs(this);
        //}

        //private static readonly Func<Entities, List<T_INFO_JIG>> compiledQuery =
        //CompiledQuery.Compile((Entities context) =>
        //    context.Set<T_INFO_JIG>().AsNoTracking().ToListAsync());

        //// Use the compiled query in your method
        //public async Task<List<T_INFO_JIG>> getAll()
        //{
        //    return await compiledQuery(_db);
        //}

        private static readonly Expression<Func<T_INFO_JIG, OBJ_T_INFO_JIG>> ProjectionExpression = e => new OBJ_T_INFO_JIG
        {
            IDJIG = e.IDJIG,
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
        public async Task<List<OBJ_T_INFO_JIG>> getAll()
        {
            return await _db.T_INFO_JIG
                .Select(ProjectionExpression)
                .AsNoTracking()
                .ToListAsync();
        }

        //public async Task<List<OBJ_T_INFO_JIG>> getAll()
        //{
        //    return await _db.T_INFO_JIG
        //        .Select(e => new OBJ_T_INFO_JIG
        //        {
        //            e.IDJIG,
        //            e.QRCODE,
        //            e.NAME,
        //            e.DESCRIPTION,
        //            e.PARTNUMBER,
        //            e.RANK,
        //            e.FIXED_ASSET_NO,
        //            e.QTY,
        //            e.BALANCE,
        //            e.PO_RQ,
        //            e.QUOTATION,
        //            e.REMARK,
        //            e.LOCATION,
        //            e.IDSTAFF,
        //            e.IDCUSTOMER,
        //            e.STATUS,
        //        })
        //        .AsNoTracking()
        //        .ToListAsync();
        //}

        public async Task<T_INFO_JIG> getByID(int _idjig)
        {
            return await _db.T_INFO_JIG.FirstOrDefaultAsync(x => x.IDJIG == _idjig);
        }

        public async Task<T_INFO_JIG> getJigbyQRCode(string _QRCode)
        {
            return await _db.T_INFO_JIG.FirstOrDefaultAsync(x => x.QRCODE == _QRCode && x.BALANCE > 0);
        }

        public async Task<int> getBalancebyID(int _idjig)
        {
            var data = await _db.T_INFO_JIG.FirstOrDefaultAsync(x => x.IDJIG == _idjig);
            return int.Parse(data.BALANCE.ToString());
        }

        public async Task<bool> checkDuplicate(string _name, string _des, string _partnumber)
        {
            var data = await _db.T_INFO_JIG.Where(x => x.NAME == _name && x.DESCRIPTION == _des && x.PARTNUMBER == _partnumber).ToListAsync();
            if (data.Count > 0)
                return true;
            return false;
        }

        public async Task Add(T_INFO_JIG _jig)
        {
            try
            {
                _db.T_INFO_JIG.Add( _jig );
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddRange (List<T_INFO_JIG> _lstJig)
        {
            try
            {
                _db.T_INFO_JIG.AddRange(_lstJig);
                await _db.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Program.log.LogMsg(Logger.LogLevel.FATAL, $"Entity: {entityValidationErrors.Entry.Entity.GetType().Name}, Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                    }
                }

                // Handle the validation errors as needed
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(T_INFO_JIG _jig)
        {
            var result = await getByID( _jig.IDJIG);
            result.NAME = _jig.NAME;
            result.DESCRIPTION = _jig.DESCRIPTION;
            result.PARTNUMBER = _jig.PARTNUMBER;
            result.RANK = _jig.RANK;
            result.FIXED_ASSET_NO = _jig.FIXED_ASSET_NO;
            result.QTY = _jig.QTY;
            result.BALANCE = _jig.BALANCE;
            result.PICTURE = _jig.PICTURE;
            result.PO_RQ = _jig.PO_RQ;
            result.QUOTATION = _jig.QUOTATION;
            result.REMARK = _jig.REMARK;
            result.LOCATION = _jig.LOCATION;
            result.IDSTAFF = _jig.IDSTAFF;
            result.IDCUSTOMER = _jig.IDCUSTOMER;
            result.UPDATE_DATE = _jig.UPDATE_DATE;
            result.UPDATE_BY = _jig.UPDATE_BY;
            result.STATUS = _jig.STATUS;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateQtybyQRCode(string _QRCode, int _balance)
        {
            var result = await _db.T_INFO_JIG.FirstOrDefaultAsync(x => x.QRCODE == _QRCode);
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
            var result = await _db.T_INFO_JIG.FirstOrDefaultAsync(x => x.QRCODE == _QRCode);
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

        public async Task Delete(int _idjig)
        {
            var data = await getByID(_idjig);
            try
            {
                _db.T_INFO_JIG.Remove(data);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
