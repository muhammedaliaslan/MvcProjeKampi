using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class istatistikController : Controller
    {
        Context c = new Context();
        public ActionResult Istatistikler()
        {

            //1) Toplam kategori sayısı
            var TotalCategory = c.Categories.Count();
            ViewBag.TotalCategoryNumber = TotalCategory;

            //2) Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var SoftwareCategory = c.Headings.Count(x => x.Category.CategoryName == "Yazılım");
            ViewBag.TotalSoftwareCategory = SoftwareCategory;

            //3) Yazar adında 'a' harfi geçen yazar sayısı
            var WriterName = c.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.WriterNameA = WriterName;

            //4) En fazla başlığa sahip kategori adı

            var MaxCategory = c.Headings.Max(x => x.Category.CategoryName);
            ViewBag.MaxCategoryName = MaxCategory;

            //5) Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            int sonuc = 0;

            var CategoryStatusTrue = c.Categories.Count(x => x.CategoryStatus == true);
            var CategoryStatusFalse = c.Categories.Count(y => y.CategoryStatus == false);

            sonuc = (CategoryStatusTrue - CategoryStatusFalse);

            ViewBag.fark = sonuc;

            return View();
        }
    }
}