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
        [Display(Name = "дата додавання")]
        public string DateAdd { get; set; }
        public string Email { get; set; }
        [Display(Name = "телефон")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "доступ")]
        public int Status { get; set; }
    }
    public class UserAddViewModel
    {
        [Display(Name = "ім'я")]
        [Required(ErrorMessage = "ім'я є обов'язковим")]
        public string FirstName { get; set; }
        [Display(Name = "прізвище")]
        public string LastName { get; set; }
        [Display(Name = "дата народження")]
        public string DateBirth { get; set; }
        [Required(ErrorMessage = "email є обов'язковим")]
        public string Email { get; set; }
        [Display(Name = "телефон")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "пароль є обов'язковим")]
        [Display(Name = "пароль")]
        public string Password { get; set; }
    }
    public class UserMsgViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    public class UserBlockViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}