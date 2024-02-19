using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers
{
    public class HIS_PARTIN
    {
        Entities _db;
        public HIS_PARTIN()
        {
            _db = Entities.CreateEntities();
        }

        public async Task<List<T_HIS_PARTIN>> getAll()
        {
            return await _db.T_HIS_PARTIN.ToListAsync();
        }

        public async Task<T_HIS_PARTIN> getByID(int _idin)
        {
            return await _db.T_HIS_PARTIN.FirstOrDefaultAsync(x => x.IDIN == _idin);
        }

        public async Task Add(T_HIS_PARTIN _partin)
        {
            try
            {
                _db.T_HIS_PARTIN.Add(_partin);
                await _db.SaveChangesAsync();
            }
            //catch (DbEntityValidationException ex)
            //{
            //    foreach (var validationError in ex.EntityValidationErrors.SelectMany(validationResult => validationResult.ValidationErrors))
            //    {
            //        Program.log.LogMsg(Logger.LogLevel.ERROR, $"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
            //    }
            //}
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add History Part In Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add History Part In Error : {0}", ex.StackTrace);
            }
        }

        public async Task Update(T_HIS_PARTIN _partin)
        {
            var result = await getByID(_partin.IDIN);
            result.NAME = _partin.NAME;
            result.PARTNUMBER = _partin.PARTNUMBER;
            result.LOCATION = _partin.LOCATION;
            result.QTY = _partin.QTY;
            result.DATEIN = _partin.DATEIN;
            result.IDUSER = _partin.IDUSER;
            result.REMARK = _partin.REMARK;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update History Part In Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update History Part In Error : {0}", ex.StackTrace);
            }
        }

        public async Task Delete(int _idout)
        {
            var data = await getByID(_idout);
            try
            {
                _db.T_HIS_PARTIN.Remove(data);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Delete History Part In Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Delete History Part In Error : {0}", ex.StackTrace);
            }
        }
    }
}
