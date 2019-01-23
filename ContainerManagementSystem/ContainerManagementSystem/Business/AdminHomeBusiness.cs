using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Common.Common;
using Repository.Repository;

namespace Business.Business
{
    public class AdminHomeBusiness
    {
        AdminHomeRepo repo = new AdminHomeRepo();
        public List<Common.Common.AdminHomeCommon> AdminnHomeContainer()
        {
            return repo.AdminHomeContainer();
        }

        public List<Common.Common.AdminHomeCommon> SearchContainer(string SearchItem)
        {
            return repo.SearchContainer(SearchItem);
        }

        public List<Common.Common.AdminHomeCommon> ViewShipment()
        {
            return repo.ViewShipment();
        }
        public List<Common.Common.AdminHomeCommon> SearchShipment(string SearchItem)
        {
            return repo.SearchShipment(SearchItem);
        }

        public List<Common.Common.AdminHomeCommon> ViewUser()
        {
            return repo.ViewUser();
        }
        public List<Common.Common.AdminHomeCommon> SearchUser(string SearchItem)
        {
            return repo.SearchUser(SearchItem);
        }

        public Common.Common.AdminHomeCommon DetailByID(int id)
        {
            return repo.DetailByID(id);
        }

        public DbResult save(Common.Common.AdminHomeCommon common)
        {

            return repo.save(common);
        }
        public DataSet GetDropDownList()
        {
            return repo.DropdownForCountry();
        }

        public DbResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public List<Common.Common.AdminHomeCommon> AdminHomeCountry()
        {
            return repo.AdminHomeCountry();
        }

        public List<Common.Common.AdminHomeCommon> SearchCountry(string CountryName)
        {
            return repo.SearchCountry(CountryName);
        }

        public Common.Common.AdminHomeCommon CountryDetailByID(int id)
        {
            return repo.CountryDetailByID(id);
        }

        public DbResult countrysave(Common.Common.AdminHomeCommon common)
        {

            return repo.Countrysave(common);
        }
        public DataSet GetDropDownList1()
        {
            return repo.DropdownForContinent();
        }

        public DbResult CountryDelete(int id)
        {
            return repo.CountryDelete(id);
        }
    }
}