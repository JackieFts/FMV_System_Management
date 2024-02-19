using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers
{
    public class SYS_FUNC
    {
        Entities _db;

        public SYS_FUNC()
        {
            _db = Entities.CreateEntities();
        }

        public async Task<List<T_SYS_FUNC>> getParent()
        {
            return await _db.T_SYS_FUNC.Where(x => x.ISGROUP == true && x.MENU == true).OrderBy(s => s.SORT).ToListAsync();
        }
        public async Task<List<T_SYS_FUNC>> getChild(string Parent)
        {
            return await _db.T_SYS_FUNC.Where(x => x.ISGROUP == false && x.MENU == true && x.PARENT == Parent).OrderBy(s => s.SORT).ToListAsync();
        }
    }
}
