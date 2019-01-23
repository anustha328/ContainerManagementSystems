using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContainerManagementSystem.Models
{
    public class LogInModel
    {
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string CountryID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserID { get; set; }
        public IEnumerable<SelectListItem> Country { get; set; }
        [NotMapped]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }
        
    }
}