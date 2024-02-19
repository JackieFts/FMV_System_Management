using FMV_SYSTEM_MANAGEMENT.Models;
using FMV_SYSTEM_MANAGEMENT.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENT.Controlers
{
    public class SYS_FUNC
    {
        Entities _db;

        public SYS_FUNC()
        {
            _db = new Entities();
        }

        public async Task<List<TSysFunc>> getParent()
        {
            return await _db.TSysFuncs.Where(x => x.Isgroup == true && x.Menu == true).OrderBy(s => s.Sort).ToListAsync();
        }
        public async Task<List<TSysFunc>> getChild(string Parent)
        {
            return await _db.TSysFuncs.Where(x => x.Isgroup == false && x.Menu == true && x.Parent == Parent).OrderBy(s => s.Sort).ToListAsync();
        }
    }
}
