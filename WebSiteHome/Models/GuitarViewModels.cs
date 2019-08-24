using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteHome.Models
{
    public class GuitarItemViewModels
    {
        public int Id { get; set; }
        [Display(Name="ім'я")]
        public string Name { get; set; }
        [Display(Name = "дата")]
        public string Date { get; set; }
        [Display(Name = "фото")]
        public string Image { get; set; }
    }

    public class GuitarAddViewModel
    {
        [Display(Name = "ім'я")]
        [Required(ErrorMessage = "ім'я є обов'язковим")]
        public string Name { get; set; }
        [Display(Name = "дата")]
        [Required(ErrorMessage = "дата є обов'язковою")]
        public string Date { get; set; }
        [Display(Name = "фото")]
        public string Image { get; set; }
    }
}