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
using Microsoft.Data.SqlClient;
using System.Diagnostics;


namespace CustomerRelationshipManagementSystem.Controllers
{
    public class CustomerCallsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerCallsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Employee")]
        // GET: CustomerCalls
        public IActionResult Index()
        {
            List<CustomerCalls> list;
            string sql = "EXEC dbo.sp_GetAllCustomersCalls";
            list = _context.Tbl_CustomerCalls.FromSqlRaw<CustomerCalls>(sql).ToList();
            //Debugger.Break();
            return View(list);

        }
        [Authorize(Roles = "Employee")]
        // GET: CustomerCalls/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Tbl_CustomerCalls == null)
            {
                return NotFound();
            }
            CustomerCalls call;
            string sql = "EXEC dbo.sp_GetACall @CallId";

            List<SqlParameter> parms = new List<SqlParameter>
    {
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@CallId", Value = id }
    };

            call = _context.Tbl_CustomerCalls.FromSqlRaw<CustomerCalls>(sql, parms.ToArray()).ToList().FirstOrDefault();

            //Debugger.Break();
            if (call == null)
            {
                return NotFound();
            }

            return View(call);
        }
        [Authorize(Roles = "Employee")]
        // GET: CustomerCalls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerCalls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerCalls customerCalls)
        {
            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlRaw("sp_AddCall {0},{1},{2}, {3}", customerCalls.DateTimeOfCall, customerCalls.Subject, customerCalls.Description, customerCalls.CustomerRefId);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Employee")]
        // GET: CustomerCalls/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Tbl_CustomerCalls == null)
            {
                return NotFound();
            }
            CustomerCalls call;
            string sql = "EXEC dbo.sp_GetACall @CallId";

            List<SqlParameter> parms = new List<SqlParameter>
    {
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@CallId", Value = id }
    };

            call = _context.Tbl_CustomerCalls.FromSqlRaw<CustomerCalls>(sql, parms.ToArray()).ToList().FirstOrDefault();

            //Debugger.Break();
            if (call == null)
            {
                return NotFound();
            }

            return View(call);
        }

        // POST: CustomerCalls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CustomerCalls customerCalls)
        {
            if (id != customerCalls.CallId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlRaw("sp_UpdateCall {0},{1},{2}, {3}, {4}", customerCalls.CallId, customerCalls.DateTimeOfCall, customerCalls.Description, customerCalls.Subject, customerCalls.CustomerRefId);

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CustomerCalls/Delete/5
        [Authorize(Roles = "Employee")]
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Tbl_CustomerCalls == null)
            {
                return NotFound();
            }
            CustomerCalls call;
            string sql = "EXEC dbo.sp_GetACall @CallId";

            List<SqlParameter> parms = new List<SqlParameter>
    {
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@CallId", Value = id }
    };

            call = _context.Tbl_CustomerCalls.FromSqlRaw<CustomerCalls>(sql, parms.ToArray()).ToList().FirstOrDefault();

            //Debugger.Break();
            if (call == null)
            {
                return NotFound();
            }

            return View(call);
        }

        // POST: CustomerCalls/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, CustomerCalls customerCalls)
        {
            if (_context.Tbl_CustomerInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tbl_CustomerInfo'  is null.");
            }

            _context.Database.ExecuteSqlRaw("sp_DeleteCall {0}", customerCalls.CallId = id);


            return RedirectToAction(nameof(Index));
        }

        private bool CustomerCallsExists(int id)
        {
            return (_context.Tbl_CustomerCalls?.Any(e => e.CallId == id)).GetValueOrDefault();
        }
    }
}
