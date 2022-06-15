using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using KT0720TênSV_61132767.Models;

namespace KT0720TênSV_61132767.Controllers
{
    public class SinhVien0720_61132767Controller : Controller
    {
        // GET: SinhVien0720_61132767
        private KT0720_61132767Entities1 db = new KT0720_61132767Entities1();

        public ActionResult GioiThieu()
        {

            return View();
        }
        public ActionResult TimKiem()
        {
            var sinhViens = db.SINHVIENs.Include(s => s.LOP);
            return View(sinhViens.ToList());
        }
        [HttpPost]
        public ActionResult TimKiem(string maSV, string HoTen)
        {

            var sinhViens = db.SINHVIENs.Include(s => s.LOP);
            if ((maSV != "") && (HoTen != ""))
            {
                sinhViens = sinhViens.Where(sv => (sv.MaSV == maSV) && (sv.HoSV + " " + sv.TenSV).Contains(HoTen));
            }
            else if ((maSV != "") && (HoTen == ""))
            {
                sinhViens = sinhViens.Where(sv => sv.MaSV == maSV);
            }

            else
            {
                sinhViens = sinhViens.Where(sv => (sv.HoSV + " " + sv.TenSV).Contains(HoTen));
            }
            return View(sinhViens.ToList());


        }
        public ActionResult Index()
        {
            var sinhViens = db.SINHVIENs.Include(s => s.LOP);
            return View(sinhViens.ToList());
        }

        // GET: SinhVien072061999999/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sinhVien = db.SINHVIENs.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhVien072061999999/Create
        public ActionResult Create()
        {
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop");
            return View();
        }

        // POST: SinhVien072061999999/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,HoSV,TenSV,GioiTinh,NgaySinh,AnhNV,DiaChi,MaLop")] SINHVIEN sinhVien)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgSV = Request.Files["Avatar"];
            //L?y thông tin t? input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgSV.FileName);
            //L?u hình ??i di?n v? Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgSV.SaveAs(path);
            if (ModelState.IsValid)
            {
                sinhVien.AnhSV = postedFileName;
                db.SINHVIENs.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", sinhVien.Malop);
            return View(sinhVien);
        }

        // GET: SinhVien072061999999/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sinhVien = db.SINHVIENs.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", sinhVien.Malop);
            return View(sinhVien);
        }

        // POST: SinhVien072061999999/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSV,HoSV,TenSV,GioiTinh,NgaySinh,AnhNV,DiaChi,MaLop")] SINHVIEN sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", sinhVien.Malop);
            return View(sinhVien);
        }

        // GET: SinhVien072061999999/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sinhVien = db.SINHVIENs.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhVien072061999999/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SINHVIEN sinhVien = db.SINHVIENs.Find(id);
            db.SINHVIENs.Remove(sinhVien);
            db.SaveChanges();
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
