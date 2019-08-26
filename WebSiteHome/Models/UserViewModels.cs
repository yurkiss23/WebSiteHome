using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteHome.Models
{
    public class UserItemViewModels
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}