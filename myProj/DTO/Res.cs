using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProj.DTO
{
    public class Res
    {
        public string RequestedBranchName { get; set; }
        public string BranchName { get; set; }
        public string CompanyName { get; set; }
        public int Kind { get; set; }

        public Res() { }
    }
}