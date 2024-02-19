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
    public class SLOGAN
    {
        Entities _dbcontext;
        public SLOGAN()
        {
            _dbcontext = new Entities();
        }

        public async Task<string> getSlogen()
        {
            var data = await _dbcontext.TSlogans.FirstOrDefaultAsync(x=> x.Id == 1);
            return data.Slogan.ToString();
        }
    }
}
