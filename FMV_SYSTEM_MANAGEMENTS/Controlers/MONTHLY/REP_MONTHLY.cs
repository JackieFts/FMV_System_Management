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
    public class REP_MONTHLY
    {
        Entities _db;
        public REP_MONTHLY()
        {
            _db = Entities.CreateEntities();
        }

        public async Task<List<View_REP_MONTHLY>> getAll()
        {
            return await _db.View_REP_MONTHLY
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T_REP_MONTHLY> getByID(int _idMonth)
        {
            return await _db.T_REP_MONTHLY.FirstOrDefaultAsync(x => x.IDMONTHLY == _idMonth);
        }

        public async Task<List<View_REP_MONTHLY>> getForSearch(DateTime _from, DateTime _to)
        {
            return await _db.View_REP_MONTHLY
                .Where(x => x.DATE >= _from && x.DATE <= _to)
                .OrderBy(x => x.DATE)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<View_REP_MONTHLY>> getForSearch(DateTime _dateadd)
        {
            return await _db.View_REP_MONTHLY
                .Where(x => x.CREATE_DATE >= _dateadd)
                .OrderBy(x => x.DATE)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Add(T_REP_MONTHLY _rep)
        {
            try
            {
                _db.T_REP_MONTHLY.Add(_rep);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Monthly Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Add Monthly Error : {0}", ex.StackTrace);
            }
        }


        public async Task Update(T_REP_MONTHLY _rep)
        {
            var data = await getByID(_rep.IDMONTHLY);
            data.IDCUSTOMER = _rep.IDCUSTOMER;
            data.IDSTAFF = _rep.IDSTAFF;
            data.DATE = _rep.DATE;
            data.DAY = _rep.DAY;
            data.CHECKIN = _rep.CHECKIN;
            data.CHECKOUT = _rep.CHECKOUT;
            data.IDMCTYPE = _rep.IDMCTYPE;
            data.LINE_NO = _rep.LINE_NO;
            data.INSTALLATION_DATE = _rep.INSTALLATION_DATE;
            data.ACTIVITY = _rep.ACTIVITY;
            data.TRANSPORT = _rep.TRANSPORT;
            data.SRNO = _rep.SRNO;
            data.NATURE = _rep.NATURE;
            data.CHARGEABLE = _rep.CHARGEABLE;
            data.UPDATE_DATE = _rep.UPDATE_DATE;
            data.UPDATE_BY = _rep.UPDATE_BY;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update Monthly Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Update Monthly Error : {0}", ex.StackTrace);
            }
        }

        public async Task Delete(int _idMonth)
        {
            var data = await getByID(_idMonth);
            try
            {
                _db.T_REP_MONTHLY.Remove(data);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Delete Monthly Error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "Delete Monthly Error : {0}", ex.StackTrace);
            }
        }

        public void TrunCate()
        {
            _db.TruncateTable("T_REP_MONTHLY");
        }
    }
}
