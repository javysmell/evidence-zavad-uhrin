using evidence_zavad_uhrin.Data;
using evidence_zavad_uhrin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace evidence_zavad_uhrin.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IssuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ
        public IActionResult Index()
        {
            var issues = _context.Issues.ToList();
            var rooms = _context.Rooms.ToList(); // pro dropdown jmen místností
            ViewBag.Rooms = rooms;
            return View(issues);
        }

        // CREATE
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(string title, string issueDescription, DateTime createdAt, string status, int roomId)
        {
            var issue = new Issues
            {
                Title = title,
                IssueDescription = issueDescription,
                CreatedAt = createdAt,   // uživatel vyplní ve formuláři
                Status = status,
                RoomId = roomId
            };
            _context.Issues.Add(issue);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                TempData["Error"] = ex.InnerException?.Message ?? ex.Message;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // UPDATE
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string title, string issueDescription, DateTime createdAt, string status, int roomId)
        {
            var issue = _context.Issues.Find(id);
            if (issue != null)
            {
                issue.Title = title;
                issue.IssueDescription = issueDescription;
                issue.CreatedAt = createdAt;
                issue.Status = status;
                issue.RoomId = roomId;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // DELETE
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var issue = _context.Issues.Find(id);
            if (issue != null)
            {
                _context.Issues.Remove(issue);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}