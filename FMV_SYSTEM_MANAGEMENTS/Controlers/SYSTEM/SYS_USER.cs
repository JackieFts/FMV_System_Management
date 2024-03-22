using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Controlers
{
    public class SYS_USER
    {
        Entities _db;
        public SYS_USER()
        {
            _db= Entities.CreateEntities();
        }

        public async Task<bool> checkAccount(string _user, string _password)
        {
            var data = await _db.T_SYS_USER.Where(x => x.USERNAME == _user && x.PASSWD == _password).FirstOrDefaultAsync();
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}
