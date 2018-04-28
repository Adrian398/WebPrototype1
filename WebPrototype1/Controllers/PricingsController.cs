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
    public class PricingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pricings
        public async Task<ActionResult> Index()
        {
            var pricings = db.Pricings.Include(p => p.Mobilfunk);
            return View(await pricings.ToListAsync());
        }

        // GET: Pricings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pricing pricing = await db.Pricings.FindAsync(id);
            if (pricing == null)
            {
                return HttpNotFound();
            }
            return View(pricing);
        }

        // GET: Pricings/Create
        public ActionResult Create()
        {
            ViewBag.MobilfunkId = new SelectList(db.Mobilfunks, "MobilfunkId", "NetworkSpeed");
            return View();
        }

        // POST: Pricings/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PricingId,Price,URL,MobilPhoneId,MobilfunkId")] Pricing pricing)
        {
            if (ModelState.IsValid)
            {
                db.Pricings.Add(pricing);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MobilfunkId = new SelectList(db.Mobilfunks, "MobilfunkId", "NetworkSpeed", pricing.MobilfunkId);
            return View(pricing);
        }

        // GET: Pricings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pricing pricing = await db.Pricings.FindAsync(id);
            if (pricing == null)
            {
                return HttpNotFound();
            }
            ViewBag.MobilfunkId = new SelectList(db.Mobilfunks, "MobilfunkId", "NetworkSpeed", pricing.MobilfunkId);
            return View(pricing);
        }

        // POST: Pricings/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PricingId,Price,URL,MobilPhoneId,MobilfunkId")] Pricing pricing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pricing).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MobilfunkId = new SelectList(db.Mobilfunks, "MobilfunkId", "NetworkSpeed", pricing.MobilfunkId);
            return View(pricing);
        }

        // GET: Pricings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pricing pricing = await db.Pricings.FindAsync(id);
            if (pricing == null)
            {
                return HttpNotFound();
            }
            return View(pricing);
        }

        // POST: Pricings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pricing pricing = await db.Pricings.FindAsync(id);
            db.Pricings.Remove(pricing);
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
