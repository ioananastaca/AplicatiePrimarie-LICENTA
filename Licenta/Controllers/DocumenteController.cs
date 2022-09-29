using Licenta.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Licenta.Controllers
{
    public class DocumenteController : Controller
    {
        // GET: Documente
        //public ActionResult Index()
        //{
        //    //Fetch all files in the Folder (Directory).
        //    string[] filePaths = Directory.GetFiles(Server.MapPath(@"C:\Users\Ioana\Desktop\New folder\Licenta\Licenta\Licenta\Documents\"));

        //    //Copy File names to Model collection.
        //    List <FileModel> files = new List<FileModel>();
        //    foreach (string filePath in filePaths)
        //    {
        //        files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
        //    }

        //    return View(files);
        //}
        //public FileResult DownloadFile(string fileName)
        //{
        //    //Build the File Path.
        //    string path = Server.MapPath(@"C:\Users\Ioana\Desktop\New folder\Licenta\Licenta\Licenta\Documents\") + fileName;

        //    //Read the File data into Byte Array.
        //    byte[] bytes = System.IO.File.ReadAllBytes(path);

        //    //Send the File to Download.
        //    return File(bytes, "application/octet-stream", fileName);
        //}

        public ActionResult InregistrareNasteri()
        {
            return View("_InregistrareNasteri");
        }
        public ActionResult InregistrareCasatorie()
        {
            return View("_Casatorie");
        }
        public ActionResult InregistrareDeces()
        {
            return View("_Deces");
        }
        public ActionResult EliberareCertificateStareCivila()
        {
            return View("_EliberareCertificate");
        }
        public ActionResult Divort()
        {
            return View("_Divort");
        }
        public ActionResult LivretulFamiliei()
        {
            return View("_LivretulFamiliei");
        }
    }
}