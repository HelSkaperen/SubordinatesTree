using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SubordinatesTree.Models;
using Microsoft.EntityFrameworkCore;

namespace SubordinatesTree.Controllers
{
    public class HomeController : Controller
    {
        private PersonContext db;
        public HomeController(PersonContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            Dictionary<long, List<PersonModel>> data = db.Persons.ToList()
                .OrderBy(r => r.LeaderId)
                .GroupBy(p => p.LeaderId, (id, item) => new { id, item })
                .ToDictionary(q => q.id, q => q.item.ToList());

            Tree PersonTree = new Tree();

            void add_branch(treeNode node)
            {
                if (!data.ContainsKey(node.personNode.PersonId)) return;
                List<PersonModel> branch = data[node.personNode.PersonId];
                foreach (var p in branch)
                {
                    treeNode pers = new treeNode(p);
                    node.add_children(pers);
                    add_branch(pers);
                }
            }
            if (data.Count != 0)
            {
                List<PersonModel> root = data[-1];
                     foreach (var p in root)
                     {
                          treeNode node = new treeNode(p);
                          PersonTree.root.Add(node);
                          add_branch(node);
                      }
            }
            
            return View(PersonTree);
        }

    }
}
        /*public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonModel person )
        {
            db.Persons.Add(person);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
 

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
