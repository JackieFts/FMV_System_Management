using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers
{
    public class V_HIS_PARTIN
    {
        Entities _db;
        public V_HIS_PARTIN()
        {
            _db = Entities.CreateEntities();
        }

        public async Task<List<View_HIS_PARTIN>> getAll()
        {
            return await _db.View_HIS_PARTIN.ToListAsync();
        }

        public async Task<List<View_HIS_PARTIN>> getByCon(DateTime _from, DateTime _to)
        {
            return await _db.View_HIS_PARTIN
                .Where(x => x.DATEIN >= _from && x.DATEIN <= _to)
                .OrderBy(x => x.DATEIN)
                .ToListAsync();
        }
    }
}
