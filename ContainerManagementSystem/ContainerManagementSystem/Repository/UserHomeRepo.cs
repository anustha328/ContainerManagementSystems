using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Common;

namespace Repository.Repository
{
    public class UserHomeRepo
    {
        RepoDAO dao;
        public UserHomeRepo()
        {
            dao = new RepoDAO();
        }

        public List<Common.Common.UserHomeCommon> UserHomeContainer()
        {

            List<Common.Common.UserHomeCommon> list = new List<Common.Common.UserHomeCommon>();
            var sql = "exec [dbo].[CMS_Container] @flag='Select'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int num = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new Common.Common.UserHomeCommon();
                    common.SN = num.ToString();
                    common.ContainerID = item["ContainerID"].ToString();
                    common.ContainerName = item["ContainerName"].ToString();
                    common.CountryName = item["CountryName"].ToString();
                    common.Status= "<a class='btn btn-xs' style='background - color:transparent' data-toggle='modal' data-target='#AddModal'  onclick='GetDetailById (" + common.ContainerID + ")'>" + item["Status"].ToString() + "</a>";
                    list.Add(common);
                    num++;
                }
            }
            return list;

        }

        public List<Common.Common.UserHomeCommon> SearchContainer(string SearchItem)
        {

            List<Common.Common.UserHomeCommon> list = new List<Common.Common.UserHomeCommon>();
            var sql = "exec [dbo].[CMS_Container] @flag='CusSearch',@SearchItem='" + SearchItem + "'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int num = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new Common.Common.UserHomeCommon();
                    common.SN = num.ToString();
                    common.ContainerID = item["ContainerID"].ToString();
                    common.ContainerName = item["ContainerName"].ToString();
                    common.CountryName = item["CountryName"].ToString();
                    common.Status = "<a class='btn btn-xs' style='background - color:transparent' data-toggle='modal' data-target='#AddModal' onclick='GetDetailById (" + common.ContainerID + ")'>" + item["Status"].ToString() + "</a>";
                    list.Add(common);
                    num++;
                }
            }
            return list;

        }

        public List<Common.Common.UserHomeCommon> ViewShipment(string UserID)
        {

            List<Common.Common.UserHomeCommon> list = new List<Common.Common.UserHomeCommon>();
            var sql = "exec [dbo].[CMS_Shipment] @flag='selects',@UserID='" + UserID + "'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int num = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new Common.Common.UserHomeCommon();
                    common.SN = num.ToString();
                    common.ShipmentID = item["ShipmentID"].ToString();
                    common.ShipmentTitle = item["ShipmentTitle"].ToString();
                    common.DepartureFrom = item["DepartureFrom"].ToString();
                    common.ArrivalTO = item["ArrivalTo"].ToString();
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



        public Common.Common.UserHomeCommon DetailByID(int id)
        {

            var common = new Common.Common.UserHomeCommon();
            var sql = "exec [CMS_User] @flag='selects', @ContainerID='" + id + "'";

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    common.ContainerID = item["ContainerID"].ToString();
                    common.ContainerName = item["ContainerName"].ToString();
                    common.CountryName = item["CountryName"].ToString();
                    common.Status = item["Status"].ToString();


                }
            }
            return common;
        }

        public System.Data.DataSet DropdownForDeparture()
        {
            var sql = "select * from Country";
            return dao.ExecuteDataset(sql);
        }


        public System.Data.DataSet DropdownForDestination()
        {
            var sql = "select * from Country";
            return dao.ExecuteDataset(sql);
        }


        public DbResult save(Common.Common.UserHomeCommon common)
        {
            System.Web.HttpContext.Current.Session["sessionString"] = 4;

            var sql = "exec [dbo].[CMS_Shipment] @flag = 'insert'" ;
            sql += ",@UserID = " + dao.FilterString(common.UserID);
            sql += ",@DepartureFrom = " + dao.FilterString(common.DepartureFrom);
            sql += ",@ArrivalTo = " + dao.FilterString(common.ArrivalTO);
            sql += ",@DepartureDate = " + dao.FilterString(common.DepartureDate);
            sql += ",@ArrivalDate = " + dao.FilterString(common.ArrivalDate);
            sql += ",@ContainerID = " + dao.FilterString(common.ContainerID);
            return dao.ParseDbResult(sql);
        }

    }
}