using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjaxLapin.Models
{
    public class Lapin
    {
        [Key]
        public int id { get; set; }
        public String nomlapalin { get; set; }
        public int age { get; set; }
    }
}