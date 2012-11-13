using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Excel = Microsoft.Office.Interop.Excel;
using Futbol.ViewModels;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using Amazon.S3.Transfer;
using System.Configuration;
using System.Collections.Specialized;
using System.Web.Providers.Entities;
using System.Net; 

namespace Futbol.Controllers
{
    public class CrearPlantillaController : Controller
    {
        //
        // GET: /CrearPlantilla/

        public ActionResult Index()
        {

            string Url = "https://s3.amazonaws.com/summumnet_profile_photos/Book1.csv";

            Uri Uri = new Uri(Url);
 
            //Create the request object
            WebRequest Request = WebRequest.Create(Uri);
            WebResponse Response = Request.GetResponse();
            Stream Stream = Response.GetResponseStream();
            StreamReader StreamReader = new StreamReader(Stream);
            PlantillaViewModels PlantillaView = new PlantillaViewModels();
            while (StreamReader.Peek() != -1) 
            {
                string Line = StreamReader.ReadLine();
                string Name = Line.Substring(0, Line.Length).Trim();
                JugadorViewModels Jugador = new JugadorViewModels();
                Jugador.Nombre = Name;
                PlantillaView.Plantilla.Add(Jugador);
            }
            return View(PlantillaView);
        }

      
        public ActionResult Upload()
        {
            return View();
        }

        // This action handles the form POST and the upload
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            NameValueCollection appConfig = ConfigurationManager.AppSettings;
            byte[] stuffToWrite = BmpToBytes(file);
            MemoryStream streamToWrite = new MemoryStream(stuffToWrite);
            string FileName = file.FileName;
            TransferUtility transferUtility = new TransferUtility(appConfig["AWSAccessKey"], appConfig["AWSSecretKey"]);
            transferUtility.Upload(streamToWrite, "summumnet_profile_photos", FileName);
            return RedirectToAction("Index");
        }

        public byte[] BmpToBytes(HttpPostedFileBase file)
        {
           
            MemoryStream ms = new MemoryStream();
            file.InputStream.CopyTo(ms);
            byte[] buffer =  ms.GetBuffer();
            //Session["xls"] = ms.ToArray();
            ms.Close();
            return buffer;
        }
    }
 }

