using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using EDIWebPortal.Data;
using EDIWebPortal.Models;
using EDIWebPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EDIWebPortal.Controllers
{
    
    public class PurchaseOrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IConverter _converter;

        public PurchaseOrderController(ApplicationDbContext db, IConverter converter)
        {
            _db = db;
            _converter = converter;
        }

        public IActionResult Index()
        {
            return View(_db.PurchaseOrder.ToList());
        }
        //public void Print()
        //{
        //    window.print();
        //}
        //GET PDF
        public IActionResult CreatePDF(int id)
        {
            PurchaseOrder purchase = new PurchaseOrder();
            try
            {
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = purchase.PONumber,
                 //   Out = @"D:\PDFCreator\Employee_Report.pdf"
                };
                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    Page = "https://localhost:44301/PurchaseOrder/Details/"+id,
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                  };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                //generating PDFs
                //CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
                //context.LoadUnmanagedLibrary("C:\\Users\\LENOVO\\source\repos\\EDIWebPortal\\EDIWebPortal\\libwkhtmltox.dll");


                var file = _converter.Convert(pdf);
                return File(file, "application/pdf", "PurchaseOrder.pdf");

            }
            catch (Exception ex)
            {

                Logger.Fatal(ex.Message);
                Logger.Fatal(ex.Source);
                Logger.Fatal(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Fatal(ex.InnerException.Message);
                    Logger.Fatal(ex.InnerException.Source);
                    Logger.Fatal(ex.InnerException.StackTrace);
                }
                return View();
            }

        }

        //GET Details Action method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var purchaseOrder = await _db.PurchaseOrder.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            return View(purchaseOrder);
        }
    }
}