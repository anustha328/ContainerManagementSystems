using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Common.Common;
using Repository.Repository;

namespace Business.Business
{
    public class UserHomeBusiness
    {
        UserHomeRepo repo = new UserHomeRepo();
        public List<Common.Common.UserHomeCommon> UserHomeContainer()
        {
             return repo.UserHomeContainer();
        }

        public List<Common.Common.UserHomeCommon> SearchContainer(string SearchItem)
        {
            return repo.SearchContainer(SearchItem);
        }

        public List<Common.Common.UserHomeCommon> ViewShipment(string UserID)
        {
            return repo.ViewShipment(UserID);
        }

        public Common.Common.UserHomeCommon DetailByID(int id)
        {
            return repo.DetailByID(id);
        }
        public DbResult save(Common.Common.UserHomeCommon common)
        {

            return repo.save(common);
        }
        public DataSet GetDropDownList()
        {
            return repo.DropdownForDeparture();
        }

        public DataSet GetDropDownList1()
        {
            return repo.DropdownForDestination();
        }

    }
}