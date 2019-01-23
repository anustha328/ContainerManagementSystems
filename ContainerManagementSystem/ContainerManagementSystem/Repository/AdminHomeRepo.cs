using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Common;

namespace Repository.Repository
{
    public class AdminHomeRepo
    {
        RepoDAO dao;
        public AdminHomeRepo()
        {
            dao = new RepoDAO();
        }

        public List<Common.Common.AdminHomeCommon> AdminHomeContainer()
        {

            List<Common.Common.AdminHomeCommon> list = new List<Common.Common.AdminHomeCommon>();
            var sql = "exec [dbo].[CMS_Container] @flag='AdminSelect'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int num = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new Common.Common.AdminHomeCommon();
                    common.SN = num.ToString();
                    common.ContainerID = item["ContainerID"].ToString();
                    common.ContainerName = item["ContainerName"].ToString();
                    common.CountryName = item["CountryName"].ToString();
                    common.Status=  item["Status"].ToString();
                    //var link = "<a class='btn btn-xs' style='background - color:transparent' data-toggle='modal' data-target='#AddModal' onclick='GetDetailById(" + common.ContainerID + ")' ><span class='btn-label glyphicon glyphicon-edit'></span>&nbsp;</a>";
                   var link = "<a id='delete' class='btn btn-xs' style='color: red' data-toggle='modal' data-target='#Confirmation'  data-id = " + common.ContainerID + " ><span class='glyphicon glyphicon-trash'></span>&nbsp;</a>";
                    common.Action = link;
                    list.Add(common);
                    num++;
                }
            }
            return list;

        }

        public List<Common.Common.AdminHomeCommon> SearchContainer(string SearchItem)
        {

            List<Common.Common.AdminHomeCommon> list = new List<Common.Common.AdminHomeCommon>();
            var sql = "exec [dbo].[CMS_Container] @flag='AdminSearch',@SearchItem='" + SearchItem + "'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int num = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new Common.Common.AdminHomeCommon();
                    common.SN = num.ToString();
                    common.ContainerID = item["ContainerID"].ToString();
                    common.ContainerName = item["ContainerName"].ToString();
                    common.CountryName = item["CountryName"].ToString();
                    common.Status = item["Status"].ToString();
                    //var link = "<a class='btn btn-xs' style='background - color:transparent' data-toggle='modal' data-target='#AddModal' onclick='GetDetailById(" + common.ContainerID + ")' ><span class='btn-label glyphicon glyphicon-edit'></span>&nbsp;</a>";
                  var  link = "<a id='delete' class='btn btn-xs' style='color: red' data-toggle='modal' data-target='#Confirmation'  data-id = " + common.ContainerID + " ><span class='glyphicon glyphicon-trash'></span>&nbsp;</a>";
                    common.Action = link;
                    list.Add(common);
                    num++;
                }
            }
            return list;

        }

        public List<Common.Common.AdminHomeCommon> ViewShipment()
        {

            List<Common.Common.AdminHomeCommon> list = new List<Common.Common.AdminHomeCommon>();
            var sql = "exec [dbo].[CMS_Shipment] @flag='select'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int num = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new Common.Common.AdminHomeCommon();
                    common.SN = num.ToString();
                    common.ShipmentID = item["ShipmentID"].ToString();
                    common.ShipmentTitle = item["ShipmentTitle"].ToString();
                    common.Name = item["Name"].ToString();
                    common.ContactNo = item["ContactNo"].ToString();
                    common.Email = item["Email"].ToString();
                    common.DepartureFrom = item["DepartureFrom"].ToString();
                    common.ArrivalTo = item["ArrivalTo"].ToString();
                    common.DepartureDate = item["DepartureDate"].ToString();
                    common.ArrivalDate = item["ArrivalDate"].ToString();
                    common.ContainerName = item["ContainerName"].ToString();
                    common.ContainerID = item["ContainerID"].ToString();
                    common.OrderDate = item["OrderDate"].ToString();
                    common.Status = item["Status"].ToString();
                    list.Add(common);
                    num++;
                }
            }
            return list;

        }

        public List<Common.Common.AdminHomeCommon> SearchShipment(string SearchItem)
        {

            List<Common.Common.AdminHomeCommon> list = new List<Common.Common.AdminHomeCommon>();
            var sql = "exec [dbo].[CMS_Shipment] @flag='AdminSearch',@SearchItem='" + SearchItem + "'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int num = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new Common.Common.AdminHomeCommon();
                    common.SN = num.ToString();
                    common.ShipmentID = item["ShipmentID"].ToString();
                    common.Name = item["Name"].ToString();
                    common.ContactNo = item["ContactNo"].ToString();
                    common.Email = item["Email"].ToString();
                    common.ShipmentTitle = item["ShipmentTitle"].ToString();
                    common.DepartureFrom = item["DepartureFrom"].ToString();
                    common.ArrivalTo = item["ArrivalTo"].ToString();
                    common.DepartureDate = item["DepartureDate"].ToString();
                    common.ArrivalDate = item["ArrivalDate"].ToString();
                    common.ContainerName = item["ContainerName"].ToString();
                    common.ContainerID = item["ContainerID"].ToString();
                    common.OrderDate = item["OrderDate"].ToString();
                    common.Status = item["Status"].ToString();
                    list.Add(common);
                    num++;
                }
            }
            return list;

        }

        public List<Common.Common.AdminHomeCommon> ViewUser()
        {

            List<Common.Common.AdminHomeCommon> list = new List<Common.Common.AdminHomeCommon>();
            var sql = "exec [dbo].[CMS_Shipment] @flag='User'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int num = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new Common.Common.AdminHomeCommon();
                    common.SN = num.ToString();
                    common.UserID = item["UserID"].ToString();
                    common.Name = item["Name"].ToString();
                    common.ContactNo = item["ContactNo"].ToString();
                    common.Email = item["Email"].ToString();
                    common.Username = item["Username"].ToString();
                    common.Password = item["Password"].ToString();
                    common.Title = item["Title"].ToString();
                    list.Add(common);
                    num++;
                }
            }
            return list;

        }

        public List<Common.Common.AdminHomeCommon> SearchUser(string SearchItem)
        {

            List<Common.Common.AdminHomeCommon> list = new List<Common.Common.AdminHomeCommon>();
            var sql = "exec [dbo].[CMS_Shipment] @flag='UserSearch',@SearchItem='" + SearchItem + "'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int num = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new Common.Common.AdminHomeCommon();
                    common.SN = num.ToString();
                    common.UserID = item["UserID"].ToString();
                    common.Name = item["Name"].ToString();
                    common.ContactNo = item["ContactNo"].ToString();
                    common.Email = item["Email"].ToString();
                    common.Username = item["Username"].ToString();
                    common.Password = item["Password"].ToString();
                    common.Title = item["Title"].ToString();
                    list.Add(common);
                    num++;
                }
            }
            return list;

        }


        public Common.Common.AdminHomeCommon DetailByID(int id)
        {

            var common = new Common.Common.AdminHomeCommon();
            var sql = "exec [CMS_Container] @flag='AdminSelects', @ContainerID='" + id + "'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    common.ContainerID = item["ContainerID"].ToString();
                    common.ContainerName = item["ContainerName"].ToString();
                    common.Country = item["CountryID"].ToString();
                    common.Status = item["Status"].ToString();
                }
            }
            return common;
        }

        public DbResult Delete(int id)
        {
            var sql = "exec [CMS_Container] @flag='Delete'";
            sql += ",@ContainerID = " + dao.FilterString(id.ToString());
            return dao.ParseDbResult(sql);
        }

        public System.Data.DataSet DropdownForCountry()
        {
            var sql = "select * from Country";
            return dao.ExecuteDataset(sql);
        }


        public System.Data.DataSet DropdownForContinent()
        {
            var sql = "select * from Zone";
            return dao.ExecuteDataset(sql);
        }


        public DbResult save(Common.Common.AdminHomeCommon common)
        {
            System.Web.HttpContext.Current.Session["sessionString"] = 4;

            var sql = "exec [dbo].[CMS_Container] @flag = " + (Convert.ToInt64(common.ContainerID) > 0 ? "'Update'" : "'insert'");
            sql += ",@ContainerName = " + dao.FilterString(common.ContainerName);
            sql += ",@CountryID = " + dao.FilterString(common.Country);
            sql += ",@ContainerID = " + dao.FilterString(common.ContainerID);
            return dao.ParseDbResult(sql);
        }

        public List<Common.Common.AdminHomeCommon> AdminHomeCountry()
        {

            List<Common.Common.AdminHomeCommon> list = new List<Common.Common.AdminHomeCommon>();
            var sql = "exec [dbo].[CMS_Admin] @flag='Select'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int num = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new Common.Common.AdminHomeCommon();
                    common.SN = num.ToString();
                    common.CountryID = item["CountryID"].ToString();
                    common.CountryName = item["CountryName"].ToString();
                    common.ZoneName = item["ZoneName"].ToString();
                    //var link = "<a class='btn btn-xs' style='background - color:transparent' data-toggle='modal' data-target='#AddModal' onclick='GetDetailById(" + common.CountryID + ")' ><span class='btn-label glyphicon glyphicon-edit'></span>&nbsp;</a>";
                  var  link = "<a id='delete' class='btn btn-xs' style='color: red' data-toggle='modal' data-target='#Confirmation'  data-id = " + common.CountryID + " ><span class='glyphicon glyphicon-trash'></span>&nbsp;</a>";
                    common.Action = link;
                    list.Add(common);
                    num++;
                }
            }
            return list;

        }

        public List<Common.Common.AdminHomeCommon> SearchCountry(string CountryName)
        {

            List<Common.Common.AdminHomeCommon> list = new List<Common.Common.AdminHomeCommon>();
            var sql = "exec [dbo].[CMS_Admin] @flag='AdminSelect',@CountryName='" + CountryName + "'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int num = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new Common.Common.AdminHomeCommon();
                    common.SN = num.ToString();
                    common.CountryID = item["CountryID"].ToString();
                    common.CountryName = item["CountryName"].ToString();
                    common.ZoneName = item["ZoneName"].ToString();
                    //var link = "<a class='btn btn-xs' style='background - color:transparent' data-toggle='modal' data-target='#AddModal' onclick='GetDetailById(" + common.CountryID + ")' ><span class='btn-label glyphicon glyphicon-edit'></span>&nbsp;</a>";
               var  link = "<a id='delete' class='btn btn-xs' style='color: red' data-toggle='modal' data-target='#Confirmation'  data-id = " + common.CountryID + " ><span class='glyphicon glyphicon-trash'></span>&nbsp;</a>";
                    common.Action = link;
                    list.Add(common);
                    num++;
                }
            }
            return list;

        }

        public Common.Common.AdminHomeCommon CountryDetailByID(int id)
        {

            var common = new Common.Common.AdminHomeCommon();
            var sql = "exec [CMS_Admin] @flag='AdminSelects', @CountryID='" + id + "'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    common.CountryID = item["CountryID"].ToString();
                    common.CountryName = item["CountryName"].ToString();
                    common.Continent = item["ZoneID"].ToString();
                }
            }
            return common;
        }

        public DbResult CountryDelete(int id)
        {
            var sql = "exec [CMS_Admin] @flag='Delete'";
            sql += ",@CountryID = " + dao.FilterString(id.ToString());
            return dao.ParseDbResult(sql);
        }

        public DbResult Countrysave(Common.Common.AdminHomeCommon common)
        {
            System.Web.HttpContext.Current.Session["sessionString"] = 4;

            var sql = "exec [dbo].[CMS_Admin] @flag = " + (Convert.ToInt64(common.Country) > 0 ? "'Update'" : "'insert'");
            sql += ",@CountryName = " + dao.FilterString(common.CountryName);
            sql += ",@ZoneID = " + dao.FilterString(common.Continent);
            sql += ",@CountryID = " + dao.FilterString(common.CountryID);
            return dao.ParseDbResult(sql);
        }

    }
}