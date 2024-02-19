using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENT.Controlers
{
    public class SLOGAN
    {
        Entities _dbcontext;
        public SLOGAN()
        {
            _dbcontext = Entities.CreateEntities();
        }

        public async Task<string> getSlogen()
        {
            var data = await _dbcontext.T_SLOGAN.FirstOrDefaultAsync(x=> x.ID == 1);
            return data.SLOGAN.ToString();
        }
    }
}
