using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteHome.Models
{
    public class UserItemViewModels
    {
        public int Id { get; set; }
        [Display (Name = "ім'я")]
        public string FirstName { get; set; }
        [Display(Name = "прізвище")]
        public string LastName { get; set; }
        [Display(Name = "дата народження")]
        public string DateBirth { get; set; }
        public string Email { get; set; }
        [Display(Name = "телефон")]
        public string Phone { get; set; }
    }
}