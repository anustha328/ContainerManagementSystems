using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using System.Configuration;
using System.IO;
using Common.Common;

namespace ContainerManagementSystem.Library
{
    public class Helper
    {
        public static string DataTableToJson(DataTable table)
        {
            if (table == null)
                return "";
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = string.IsNullOrEmpty(row[col].ToString()) ? "" : row[col];
                }
                list.Add(dict);
            }
            var serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(list);
            return json;
        }
        public static string StringToJson(string msg)
        {
            if (msg == null)
                return "";
            var list = new List<Dictionary<string, object>>();
            var dict = new Dictionary<string, object>();
            dict["msg"] = msg;
            var serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(dict);
            return json;
        }
        public static string ReadSession(string key, string defVal)
        {
            try
            {
                return HttpContext.Current.Session[key] == null ? defVal : HttpContext.Current.Session[key].ToString();
            }
            catch (Exception ex)
            {
                return defVal;
            }
        }

        //public static bool HasRight(string menuName,string  type)
        //{
        //    try
        //    {
        //        var menus =(List<UserRights>) HttpContext.Current.Session["rights"] ;
        //        var returnVal = false;
        //        switch (type.ToLower())
        //        {
        //            case "v":
        //                returnVal = menus.Where(f => f.ModuleName == menuName && f.View == true).Count() > 0;
        //                break;
        //            case "a":
        //                returnVal = menus.Where(f => f.ModuleName == menuName && f.add == true).Count() > 0;
        //                break;
        //            case "e":
        //                returnVal = menus.Where(f => f.ModuleName == menuName && f.Edit == true).Count() > 0;
        //                break;
        //            case "d":
        //                returnVal = menus.Where(f => f.ModuleName == menuName && f.Delete == true).Count() > 0;
        //                break;
        //            default:
        //                return returnVal;
        //        }
        //        return returnVal;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public static string GetEsewaUrl()
        {
            return ConfigurationManager.AppSettings["esewaUrl"].ToString();
        }
        public static string GetEsewaServiceCode()
        {
            return ConfigurationManager.AppSettings["esewaCode"].ToString();
        }
        public static string GetAppRoot()
        {
            return ConfigurationManager.AppSettings["appRoot"].ToString();
        }
        public static string GeturlRoot()
        {
            return ConfigurationManager.AppSettings["urlRoot"].ToString();
        }
        public static string GetUploadFileSize()
        {
            return ConfigurationManager.AppSettings["uploadFileSize"].ToString();
        }
        public static string GetSessionID()
        {
            if (string.IsNullOrWhiteSpace(ReadSession("SessionId", "")))
            {
                WriteSession("SessionId", HttpContext.Current.Session.SessionID);
            }
            return ReadSession("SessionId", "");
        }
        public static string GetUserid()
        {
            return ReadSession("userid", "");
        }
        public static string GetBranchId()
        {
            return ReadSession("BranchID", "");
        }
        public static string GetUserName()
        {
            return ReadSession("username", "");
        }
        public static string GetNotification()
        {
            return ReadSession("shownotify", "");
        }
        public static void WriteSession(string key, string value)
        {
            HttpContext.Current.Session[key] = value;
        }
        public static long ReadNumericDataFromQueryString(string key)
        {
            var tmpId = ReadQueryString(key, "0");
            long tmpIdLong;
            long.TryParse(tmpId, out tmpIdLong);
            return tmpIdLong;
        }
        public static string ReadQueryString(string key, string defVal)
        {
            return HttpContext.Current.Request.QueryString[key] ?? defVal;
        }
        public static void RemoveSession(string key)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                return;
            }
            HttpContext.Current.Session.Remove(key);
        }
        public static List<SelectListItem> SetDDLValue(DataTable dt, string selectedVal, string defLabel = "")
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (!string.IsNullOrWhiteSpace(defLabel))
            {
                items.Add(new SelectListItem { Text = defLabel, Value = "" });
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == selectedVal)
                    {
                        items.Add(new SelectListItem { Text = dt.Rows[i][1].ToString(), Value = dt.Rows[i][0].ToString(), Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = dt.Rows[i][1].ToString(), Value = dt.Rows[i][0].ToString() });
                    }
                }
            }
            return items;
        }
        //public static List<SelectListItem> SetDDLValue(List<DropdownList> list, string selectedVal, string defLabel = "")
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    if (!string.IsNullOrWhiteSpace(defLabel) && string.IsNullOrWhiteSpace(selectedVal))
        //    {
        //        items.Add(new SelectListItem { Text = defLabel, Value = "",Selected=true });
        //    }
        //    if (list.Count > 0)
        //    {
        //        foreach (var item in list)
        //        {
        //            if (item.ID.ToString()==selectedVal)
        //            {
        //                items.Add(new SelectListItem { Text = item.value, Value = item.ID.ToString(), Selected = true });
        //            }
        //            else
        //                items.Add(new SelectListItem { Text = item.value, Value = item.ID.ToString() });
        //        }
        //    }
        //    return items;
        //}

        public static bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }
    }
}