using evidence_zavad_uhrin.Data;
using evidence_zavad_uhrin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace evidence_zavad_uhrin.Controllers
{
    //[Authorize]
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ
        public IActionResult Index()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

        // CREATE
        [HttpPost]
        public IActionResult Create(string name, int floor, string roomDescription)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var room = new Room {
                    Name = name,
                    Floor = floor,
                    RoomDescription = roomDescription,
                };

                _context.Rooms.Add(room);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // UPDATE
        [HttpPost]
        public IActionResult Edit(int id, string name, int floor, string roomDescription)
        {
            var room = _context.Rooms.Find(id);
            if (room != null)
            {
                room.Name = name;
                room.Floor = floor;
                room.RoomDescription = roomDescription;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // DELETE
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
