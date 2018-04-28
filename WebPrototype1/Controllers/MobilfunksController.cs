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
    public class MobilfunksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mobilfunks
        public async Task<ActionResult> Index()
        {
            var mobilfunks = db.Mobilfunks.Include(m => m.Contract);
            return View(await mobilfunks.ToListAsync());
        }

        // GET: Mobilfunks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobilfunk mobilfunk = await db.Mobilfunks.FindAsync(id);
            if (mobilfunk == null)
            {
                return HttpNotFound();
            }
            return View(mobilfunk);
        }

        // GET: Mobilfunks/Create
        public ActionResult Create()
        {
            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Name");
            return View();
        }

        // POST: Mobilfunks/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MobilfunkId,DataVolume,FreeMinutes,FreeSMS,EURoaming,NetworkSpeed,NetworkThrottling,Network,RunningTime,SustainYourNumber,ContractId")] Mobilfunk mobilfunk)
        {
            if (ModelState.IsValid)
            {
                db.Mobilfunks.Add(mobilfunk);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Name", mobilfunk.ContractId);
            return View(mobilfunk);
        }

        // GET: Mobilfunks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobilfunk mobilfunk = await db.Mobilfunks.FindAsync(id);
            if (mobilfunk == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Name", mobilfunk.ContractId);
            return View(mobilfunk);
        }

        // POST: Mobilfunks/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MobilfunkId,DataVolume,FreeMinutes,FreeSMS,EURoaming,NetworkSpeed,NetworkThrottling,Network,RunningTime,SustainYourNumber,ContractId")] Mobilfunk mobilfunk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobilfunk).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "Name", mobilfunk.ContractId);
            return View(mobilfunk);
        }

        // GET: Mobilfunks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobilfunk mobilfunk = await db.Mobilfunks.FindAsync(id);
            if (mobilfunk == null)
            {
                return HttpNotFound();
            }
            return View(mobilfunk);
        }

        // POST: Mobilfunks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mobilfunk mobilfunk = await db.Mobilfunks.FindAsync(id);
            db.Mobilfunks.Remove(mobilfunk);
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
