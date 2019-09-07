using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebSiteHome.Models;

namespace WebSiteHome.Entities
{
    [Table("tblCombos")]
    public class TCombo
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}