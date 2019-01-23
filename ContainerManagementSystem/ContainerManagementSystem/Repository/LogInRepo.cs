using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Common;

namespace Repository.Repository
{
    public class LogInRepo
    {
        RepoDAO dao;
        public LogInRepo()
        {
            dao = new RepoDAO();
        }

        public Common.Common.LogInCommon Login(string Username, string Password)
        {

            var common = new Common.Common.LogInCommon();
            var sql = "exec [CMS_User] @flag='login',@UserName='" + Username + "',@Password='" + Password + "'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    common.UserID = item["UserID"].ToString();
                    common.Username = item["Username"].ToString();
                    common.Password = item["Password"].ToString();

                }
            }
            return common;
        }

       
        public DbResult Save(Common.Common.LogInCommon common)
        {
            System.Web.HttpContext.Current.Session["sessionString"] = 4;

            var sql = "exec [CMS_User] @flag = " + (Convert.ToInt64(common.UserID) > 0 ? "'Update'" : "'Insert'");

            sql += ",@Name = " + dao.FilterString(common.Name);
            sql += ",@ContactNo = " + dao.FilterString(common.ContactNo);
            sql += ",@Email = " + dao.FilterString(common.Email);
            sql += ",@Username = " + dao.FilterString(common.Username);
            sql += ",@Password = " + dao.FilterString(common.Password);
            sql += ",@ConfirmPassword = " + dao.FilterString(common.Password);
            sql += ",@UserID = " + dao.FilterString(common.UserID);
            return dao.ParseDbResult(sql);
        }

    }
}