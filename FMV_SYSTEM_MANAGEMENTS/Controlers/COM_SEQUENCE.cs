using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers
{
    public class COM_SEQUENCE
    {
        Entities _db;
        public COM_SEQUENCE()
        {
            _db = Entities.CreateEntities();
        }

        public async Task<int> getSequenceByName(string _name)
        {
            var result = await _db.T_COM_SEQUENCE.FirstOrDefaultAsync(x => x.SEQNAME == _name);
            return result.SEQVALUE;
        }

        public async Task updateValue(string _name, int _value)
        {
            var result = await _db.T_COM_SEQUENCE.FirstOrDefaultAsync(x => x.SEQNAME == _name);
            if (result != null)
            {
                result.SEQVALUE = _value;
                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Program.log.LogMsg(Logger.LogLevel.FATAL, "Update Sequence value error : {0}", ex.Message);
                    Program.log.LogMsg(Logger.LogLevel.FATAL, "Update Sequence value error : {0}", ex.StackTrace);
                }
            }
        }
    }
}
