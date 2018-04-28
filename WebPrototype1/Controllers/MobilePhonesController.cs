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
    public class MobilePhonesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MobilePhones
        public async Task<ActionResult> Index()
        {
            var mobilePhones = db.MobilePhones.Include(m => m.MobilePhoneProvider);
            return View(await mobilePhones.ToListAsync());
        }

        // GET: MobilePhones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobilePhone mobilePhone = await db.MobilePhones.FindAsync(id);
            if (mobilePhone == null)
            {
                return HttpNotFound();
            }
            return View(mobilePhone);
        }

        // GET: MobilePhones/Create
        public ActionResult Create()
        {
            ViewBag.MobilePhoneProviderId = new SelectList(db.MobilePhoneProviders, "MobilePhoneProviderId", "Name");
            return View();
        }

        // POST: MobilePhones/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MobilePhoneId,Name,URL,MobilePhoneProviderId")] MobilePhone mobilePhone)
        {
            if (ModelState.IsValid)
            {
                db.MobilePhones.Add(mobilePhone);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MobilePhoneProviderId = new SelectList(db.MobilePhoneProviders, "MobilePhoneProviderId", "Name", mobilePhone.MobilePhoneProviderId);
            return View(mobilePhone);
        }

        // GET: MobilePhones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobilePhone mobilePhone = await db.MobilePhones.FindAsync(id);
            if (mobilePhone == null)
            {
                return HttpNotFound();
            }
            ViewBag.MobilePhoneProviderId = new SelectList(db.MobilePhoneProviders, "MobilePhoneProviderId", "Name", mobilePhone.MobilePhoneProviderId);
            return View(mobilePhone);
        }

        // POST: MobilePhones/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MobilePhoneId,Name,URL,MobilePhoneProviderId")] MobilePhone mobilePhone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobilePhone).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MobilePhoneProviderId = new SelectList(db.MobilePhoneProviders, "MobilePhoneProviderId", "Name", mobilePhone.MobilePhoneProviderId);
            return View(mobilePhone);
        }

        // GET: MobilePhones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobilePhone mobilePhone = await db.MobilePhones.FindAsync(id);
            if (mobilePhone == null)
            {
                return HttpNotFound();
            }
            return View(mobilePhone);
        }

        // POST: MobilePhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MobilePhone mobilePhone = await db.MobilePhones.FindAsync(id);
            db.MobilePhones.Remove(mobilePhone);
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
