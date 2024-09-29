using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myProj.Models
    {
    public class CompaniesBranches
    {
        [Key]
        public string Name { get; set; }

        public string CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Companies Companies { get; set; }
    }
}
