using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPrototype1.Models;

namespace WebPrototype1.Controllers
{
    public class ContractsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contracts
        public async Task<ActionResult> Index()
        {
            var contracts = db.Contracts.Include(c => c.Provider);
            return View(await contracts.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = await db.Contracts.FindAsync(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name");
            return View();
        }

        // POST: Contracts/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ContractId,Name,URL,ProviderId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contract);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name", contract.ProviderId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = await db.Contracts.FindAsync(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name", contract.ProviderId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ContractId,Name,URL,ProviderId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name", contract.ProviderId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = await db.Contracts.FindAsync(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contract contract = await db.Contracts.FindAsync(id);
            db.Contracts.Remove(contract);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
