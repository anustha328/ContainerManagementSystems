using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContainerManagementSystem.Models
{
    public class UserHomeModel
    {
        public string ContainerID { get; set; }
        public string ContainerName { get; set; }
        public string Status { get; set; }
        public string ShipmentID { get; set; }
        public string DepartureFrom { get; set; }
        public IEnumerable<SelectListItem> Departure { get; set; }
        public string ArrivalTO { get; set; }
        public IEnumerable<SelectListItem> Destination { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureTime { get; set; }
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CountryName { get; set; }
        public string ShipmentTitle { get; set; }
        public string OrderDate { get; set; }
    }
}