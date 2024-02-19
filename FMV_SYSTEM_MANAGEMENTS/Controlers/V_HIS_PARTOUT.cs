using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers
{
    public class V_HIS_PARTOUT
    {
        Entities _db;
        public V_HIS_PARTOUT()
        {
            _db = Entities.CreateEntities();
        }

        public async Task<List<View_HIS_PARTOUT>> getAll()
        {
            return await _db.View_HIS_PARTOUT.ToListAsync();
        }

        public async Task<List<View_HIS_PARTOUT>> getByCon(DateTime _from, DateTime _to, string _idcus)
        {
            if(_idcus == "")
            {
                return await _db.View_HIS_PARTOUT
                    .Where(x => x.DATEOUT >= _from && x.DATEOUT <= _to && (x.IDCUSTOMER == "" || x.IDCUSTOMER == null))
                    .OrderBy(x => x.DATEOUT)
                    .ToListAsync();
            }
            else
            {
                return await _db.View_HIS_PARTOUT
                    .Where(x => x.DATEOUT >= _from && x.DATEOUT <= _to && x.IDCUSTOMER == _idcus)
                    .OrderBy(x => x.DATEOUT)
                    .ToListAsync();
            }
        }
    }
}
