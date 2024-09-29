using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using myProj.Models;
using System.Diagnostics;

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
            var companiesBranches = db.CompaniesBranchesT
                .Include(cb => cb.Companies)
                .ToList();

            var dtoList = companiesBranches
                .SelectMany(item =>
                    companiesBranches
                    .Where(el => (el.Companies.Name == item.Companies.Name && el.Companies.Kind == 1) ||
                                 (el.Companies.Kind == item.Companies.Kind && el.Companies.Kind == 2))
                    .Select(el => new DTO.Res
                    {
                        RequestedBranchName = item.Name,
                        BranchName = el.Name,
                        CompanyName = item.Companies.Name,
                        Kind = item.Companies.Kind
                    })
                )
                .ToList();

            return View(dtoList);
        }
    }
}
