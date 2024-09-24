using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

    namespace myProj.Models
    {

    public class CompaniesBranches
    {
        [Key] public string Name { get; set; }
        public string CompanyId { get; set; }
    }
    }
