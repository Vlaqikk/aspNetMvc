using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using myProj.Models;

namespace myProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ComContext db;

        public HomeController(ComContext context)
        {
            db = context;
        }

        public HomeController() : this(new ComContext()) 
        {
        }

        public ActionResult Index()
        {
            var table = new List<Main>();
            var res = new List<ResultType>();
            var companiesBranches = db.CompaniesBranches.ToList();

            foreach (var branch in companiesBranches)
            {
                var company = db.Companies
                    .Where(c => c.Name == branch.CompanyId && (c.Kind == "1" || c.Kind == "2"))
                    .Select(c => new
                    {
                        BranchName = branch.Name,
                        CompanyName = c.Name,
                        Kind = c.Kind
                    })
                    .FirstOrDefault();

                if (company != null)
                {
                    table.Add(new Main
                    {
                        BranchName = company.BranchName,
                        CompanyName = company.CompanyName,
                        Kind = company.Kind
                    });
                }
            }

            foreach (var company in table)
            {
                foreach (var tab in table)
                {
                    if (company.Kind == Char.ToString('1') && tab.CompanyName == company.CompanyName)
                    {
                        res.Add(new ResultType
                        {
                            RequestedBranchName = company.BranchName,
                            BranchName = tab.BranchName,
                            CompanyName = tab.CompanyName,
                            Kind = tab.Kind
                        });
                    }
                    else if (company.Kind == Char.ToString('2') && tab.Kind == Char.ToString('2'))
                    {
                        res.Add(new ResultType
                        {
                            RequestedBranchName = company.BranchName,
                            BranchName = tab.BranchName,
                            CompanyName = tab.CompanyName,
                            Kind = company.Kind
                        });
                    }
                }
            }

            return View(res);
        }
    }
}
