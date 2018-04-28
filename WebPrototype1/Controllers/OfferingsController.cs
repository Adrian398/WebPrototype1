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
    public class OfferingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Offerings
        public async Task<ActionResult> Index()
        {
            var offerings = db.Offerings.Include(o => o.Provider);
            return View(await offerings.ToListAsync());
        }

        // GET: Offerings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offering offering = await db.Offerings.FindAsync(id);
            if (offering == null)
            {
                return HttpNotFound();
            }
            return View(offering);
        }

        // GET: Offerings/Create
        public ActionResult Create()
        {
            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name");
            return View();
        }

        // POST: Offerings/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OfferingId,Name,ProviderId")] Offering offering)
        {
            if (ModelState.IsValid)
            {
                db.Offerings.Add(offering);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name", offering.ProviderId);
            return View(offering);
        }

        // GET: Offerings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offering offering = await db.Offerings.FindAsync(id);
            if (offering == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name", offering.ProviderId);
            return View(offering);
        }

        // POST: Offerings/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OfferingId,Name,ProviderId")] Offering offering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offering).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name", offering.ProviderId);
            return View(offering);
        }

        // GET: Offerings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offering offering = await db.Offerings.FindAsync(id);
            if (offering == null)
            {
                return HttpNotFound();
            }
            return View(offering);
        }

        // POST: Offerings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Offering offering = await db.Offerings.FindAsync(id);
            db.Offerings.Remove(offering);
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
