using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerRelationshipManagementSystem.Data;
using CustomerRelationshipManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;

namespace CustomerRelationshipManagementSystem.Controllers
{
    public class CustomerInfoController : Controller
    {
        private readonly ApplicationDbContext _context;


        public CustomerInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Manager")]
        // GET: CustomerInfo
        public IActionResult Index()
        {
            List<CustomerInfo> list;
            string sql = "EXEC dbo.sp_GetAllCustomers";
            list = _context.Tbl_CustomerInfo.FromSqlRaw<CustomerInfo>(sql).ToList();
            //Debugger.Break();
            return View(list);
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Tbl_CustomerInfo == null)
            {
                return NotFound();
            }

            CustomerInfo cust;
            string sql = "EXEC dbo.sp_GetACustomer @CustomerId";

            List<SqlParameter> parms = new List<SqlParameter>
    {
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@CustomerId", Value = id }
    };

            cust = _context.Tbl_CustomerInfo.FromSqlRaw<CustomerInfo>(sql, parms.ToArray()).ToList().FirstOrDefault();

            //Debugger.Break();


            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        // GET: CustomerInfo/Create
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlRaw("sp_AddCustomer {0},{1},{2}, {3}, {4}", customerInfo.CustomerName, customerInfo.CustomerSurname, customerInfo.CustomerAddress, customerInfo.CustomerCountry, customerInfo.CustomerDoB);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CustomerInfo/Edit/5
        [Authorize(Roles = "Manager")]
        public IActionResult Edit(int? id)
        {
            CustomerInfo cust;
            string sql = "EXEC dbo.sp_GetACustomer @CustomerId";

            List<SqlParameter> parms = new List<SqlParameter>
    {
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@CustomerId", Value = id }
    };

            cust = _context.Tbl_CustomerInfo.FromSqlRaw<CustomerInfo>(sql, parms.ToArray()).ToList().FirstOrDefault();

            //Debugger.Break();

            return View(cust);
        }

        // POST: CustomerInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CustomerInfo customerInfo)
        {
            if (id != customerInfo.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlRaw("sp_UpdateCustomer {0},{1},{2}, {3}, {4} ,{5}", customerInfo.CustomerId, customerInfo.CustomerName, customerInfo.CustomerSurname, customerInfo.CustomerAddress, customerInfo.CustomerCountry, customerInfo.CustomerDoB);

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CustomerInfo/Delete/5
        [Authorize(Roles = "Manager")]
        public IActionResult Delete(int? id)
        {
            CustomerInfo cust;
            string sql = "EXEC dbo.sp_GetACustomer @CustomerId";

            List<SqlParameter> parms = new List<SqlParameter>
    {
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@CustomerId", Value = id }
    };

            cust = _context.Tbl_CustomerInfo.FromSqlRaw<CustomerInfo>(sql, parms.ToArray()).ToList().FirstOrDefault();

            //Debugger.Break();

            return View(cust);
        }


        // POST: CustomerInfo/Delete/5
        [Authorize(Roles = "Manager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, CustomerInfo customerInfo)
        {
            if (_context.Tbl_CustomerInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tbl_CustomerInfo'  is null.");
            }

            _context.Database.ExecuteSqlRaw("sp_DeleteCustomer {0}", customerInfo.CustomerId = id);


            return RedirectToAction(nameof(Index));
        }

        private bool CustomerInfoExists(int id)
        {
            return (_context.Tbl_CustomerInfo?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
