using DevExpress.ClipboardSource.SpreadsheetML;
using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers
{
    public class HIS_PARTOUT
    {
        Entities _db;
        public HIS_PARTOUT()
        {
            _db = Entities.CreateEntities();
        }

        public async Task<List<T_HIS_PARTOUT>> getAll()
        {
            return await _db.T_HIS_PARTOUT.ToListAsync();
        }

        public async Task<T_HIS_PARTOUT> getByID(int _idout)
        {
            return await _db.T_HIS_PARTOUT.FirstOrDefaultAsync(x => x.IDOUT == _idout);
        }

        public async Task<List<T_HIS_PARTOUT>> getOutByQRCode(string _QRCode)
        {
            return await _db.T_HIS_PARTOUT.Where(x => x.QRCODE == _QRCode && x.STATUS == true).ToListAsync();
        }

        public async Task<int> getQtyByID(int _idjig)
        {
            var result = await _db.T_HIS_PARTOUT.FirstOrDefaultAsync(x => x.IDOUT == _idjig);
            return int.Parse(result.QTY.ToString());
        }

        public async Task Add(T_HIS_PARTOUT _partout)
        {
            try
            {
                _db.T_HIS_PARTOUT.Add(_partout);
                await _db.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationError in ex.EntityValidationErrors.SelectMany(validationResult => validationResult.ValidationErrors))
                {
                    Program.log.LogMsg(Logger.LogLevel.FATAL, "Error Add History Part Out Property: {0}, Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add History Part Out Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add History Part Out Error : {0}", ex.StackTrace);
            }
        }

        public async Task Update(T_HIS_PARTOUT _partout)
        {
            var result = await getByID(_partout.IDOUT);
            result.NAME = _partout.NAME;
            result.PARTNUMBER = _partout.PARTNUMBER;
            result.LOCATION = _partout.LOCATION;
            result.QTY = _partout.QTY;
            result.SAVEQTY = _partout.SAVEQTY;
            result.DATEOUT = _partout.DATEOUT;
            result.ESTIMATEDIN = _partout.ESTIMATEDIN;
            result.IDUSER = _partout.IDUSER;
            result.IDCUSTOMER = _partout.IDCUSTOMER;
            result.REMARK = _partout.REMARK;
            result.STATUS = _partout.STATUS;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update History Part Out Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update History Part Out Error : {0}", ex.StackTrace);
            }
        }

        public async Task UpdateStatusbyQRCode(string _QRCode, bool _status)
        {
            var result = await _db.T_HIS_PARTOUT.FirstOrDefaultAsync(x => x.QRCODE == _QRCode);
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

        public async Task UpdateStatusbySubQRCode(string _subQRCode, bool _status)
        {
            var result = await _db.T_HIS_PARTOUT.FirstOrDefaultAsync(x => x.QRCODESUB == _subQRCode);
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


        public async Task Delete(int _idout)
        {
            var data = await getByID(_idout);
            try
            {
                _db.T_HIS_PARTOUT.Remove(data);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
