using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AjaxLapin.Models
{
    public class lapinContext:DbContext
    {
        public lapinContext() : base("connLapin") { }
        
        public DbSet<Lapin> lapins { get; set; }
    }
}