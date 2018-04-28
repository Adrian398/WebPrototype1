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
    public class MobilePhoneProvidersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MobilePhoneProviders
        public async Task<ActionResult> Index()
        {
            return View(await db.MobilePhoneProviders.ToListAsync());
        }

        // GET: MobilePhoneProviders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobilePhoneProvider mobilePhoneProvider = await db.MobilePhoneProviders.FindAsync(id);
            if (mobilePhoneProvider == null)
            {
                return HttpNotFound();
            }
            return View(mobilePhoneProvider);
        }

        // GET: MobilePhoneProviders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MobilePhoneProviders/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MobilePhoneProviderId,Name,URL")] MobilePhoneProvider mobilePhoneProvider)
        {
            if (ModelState.IsValid)
            {
                db.MobilePhoneProviders.Add(mobilePhoneProvider);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mobilePhoneProvider);
        }

        // GET: MobilePhoneProviders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobilePhoneProvider mobilePhoneProvider = await db.MobilePhoneProviders.FindAsync(id);
            if (mobilePhoneProvider == null)
            {
                return HttpNotFound();
            }
            return View(mobilePhoneProvider);
        }

        // POST: MobilePhoneProviders/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MobilePhoneProviderId,Name,URL")] MobilePhoneProvider mobilePhoneProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobilePhoneProvider).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mobilePhoneProvider);
        }

        // GET: MobilePhoneProviders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobilePhoneProvider mobilePhoneProvider = await db.MobilePhoneProviders.FindAsync(id);
            if (mobilePhoneProvider == null)
            {
                return HttpNotFound();
            }
            return View(mobilePhoneProvider);
        }

        // POST: MobilePhoneProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MobilePhoneProvider mobilePhoneProvider = await db.MobilePhoneProviders.FindAsync(id);
            db.MobilePhoneProviders.Remove(mobilePhoneProvider);
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
