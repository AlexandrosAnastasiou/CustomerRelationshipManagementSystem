using CustomerRelationshipManagementSystem.Data;
using CustomerRelationshipManagementSystem.Models;
using CustomerRelationshipManagementSystem.ViewModels;
using FastReport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomerRelationshipManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Manager")]
        // GET: CustomerInfo
        public IActionResult Index()
        {
            /*List<ReportViewModel> list;
            string sql = "EXEC dbo.sp_GetAllCustomersnCalls";
            list = _context.Tbl_CustomerInfo.FromSqlRaw<ReportViewModel>(sql).ToList();
            //Debugger.Break();*/
            return View();
        }
        /*
        public FileResult Generate()
        {
            FastReport.Utils.Config.WebMode = true;
            Report rep = new Report();
            string path = "~/Customers.frx";
            rep.Load(path);

            List<CustomerInfo> cust = new List<CustomerInfo>();

        }*/
    }
}
