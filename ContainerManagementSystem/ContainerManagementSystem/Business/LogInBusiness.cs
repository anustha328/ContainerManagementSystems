using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Repository;
using Common.Common;
using System.Data;

namespace Business.Business
{
    public class LogInBusiness
    {
        LogInRepo repo = new LogInRepo();

        public Common.Common.LogInCommon LogIn(string Username, string Password)
        {
            return repo.Login(Username, Password);
        }

        public DbResult Save(Common.Common.LogInCommon common)
        {

            return repo.Save(common);
        }
      
    }
}