using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace myProj.Models
{
    public class ComContext : DbContext
    {
        public ComContext() : base("Conn")
        {
        }
        public DbSet<Companies> CompaniesT { get; set; }
        public DbSet<CompaniesBranches> CompaniesBranchesT { get; set; }
    }
}