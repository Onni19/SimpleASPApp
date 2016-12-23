using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleASPApp.Models
{
    public class ContextEntites:DbContext
    {
       ////ctor
       // public ContextEntites():base("")
       // {
            
       // }

        public DbSet<Person> People { set; get; } //in databade .. table name will b People


    }
}