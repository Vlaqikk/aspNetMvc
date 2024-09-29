using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace myProj.Models {

    public class Companies
    {
        [Key]
        public string Name { get; set; }
        public int Kind { get; set; }

        public ICollection<CompaniesBranches> Branches { get; set; }
        public Companies()
        {
            Branches = new List<CompaniesBranches>();
        }
    }
}
