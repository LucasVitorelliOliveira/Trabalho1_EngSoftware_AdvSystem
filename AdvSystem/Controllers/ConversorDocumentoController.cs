using AdvSystem.Filters;
using LovePdf.Core;
using LovePdf.Model.Enums;
using LovePdf.Model.Task;
using LovePdf.Model.TaskParams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvSystem.Controllers
{
    [UsuarioLogado]
    public class ConversorDocumentoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        string publickey = "project_public_bbd1c47dbff4447826da0f6203895073_csXQp1641b6de7c4a461e6d4d6bcecfcd4059";
        string privatekey = "secret_key_d95da9983dbdd670c8b42bcd3446853c_DCAVa041499be8fc5871f1241706cd6f1d65d";

        public ConversorDocumentoController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: ConversorDocumentoController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IMGpPDF()
        {
            return View();
        }

        public ActionResult PDFpIMG()
        {
            return View();
        }
        
        public ActionResult DOCpPDF()
        {
            return View();
        }

        public async Task<IActionResult> IMGpPDFConvert(IFormFile file)
        {
            string filepath = Path.GetFullPath(file.FileName);
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            string filename = Path.GetFileName(file.FileName);
            string filesavepath = Path.Combine(uploadsFolder, filename);

            Console.WriteLine(filesavepath);

            using (FileStream stream = new FileStream(filesavepath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var lovePdfAPi = new LovePdfApi(publickey, privatekey);
            // Create a new task
            var taskImageToPDF = lovePdfAPi.CreateTask<ImageToPdfTask>();
            // Add files to task for upload
            var file1 = taskImageToPDF.AddFile(filesavepath);
            // Execute the task
            taskImageToPDF.Process();
            // Download the package files
            taskImageToPDF.DownloadFile("C:\\Users\\lucas\\Downloads");

            if (System.IO.File.Exists(filesavepath))
            {
                System.IO.File.Delete(filesavepath);
                return RedirectToAction(nameof(IMGpPDF));
            }

            return RedirectToAction(nameof(IMGpPDF));
        }
        public async Task<IActionResult> PDFpIMGConvert(IFormFile file)
        {
            string filepath = Path.GetFullPath(file.FileName);
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            string filename = Path.GetFileName(file.FileName);
            string filesavepath = Path.Combine(uploadsFolder, filename);

            Console.WriteLine(filesavepath);

            using (FileStream stream = new FileStream(filesavepath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var lovePdfAPi = new LovePdfApi(publickey, privatekey);
            // Create a new task
            var taskPDFtoJPG = lovePdfAPi.CreateTask<PdfToJpgTask>();
            // Add files to task for upload
            var file1 = taskPDFtoJPG.AddFile(filesavepath);
            // Execute the task
            taskPDFtoJPG.Process(new PdftoJpgParams { PdfJpgMode = PdfToJpgModes.Pages });
            // Download the package files
            taskPDFtoJPG.DownloadFile("C:\\Users\\lucas\\Downloads");

            if (System.IO.File.Exists(filesavepath))
            {
                System.IO.File.Delete(filesavepath);
                return RedirectToAction(nameof(PDFpIMG));
            }

            return RedirectToAction(nameof(PDFpIMG));
        }

        public async Task<IActionResult> DOCpPDFConvert(IFormFile file)
        {
            string filepath = Path.GetFullPath(file.FileName);
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            string filename = Path.GetFileName(file.FileName);
            string filesavepath = Path.Combine(uploadsFolder, filename);

            Console.WriteLine(filesavepath);

            using (FileStream stream = new FileStream(filesavepath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var lovePdfAPi = new LovePdfApi(publickey, privatekey);
            // Create a new task
            var taskConvertOffice = lovePdfAPi.CreateTask<OfficeToPdfTask>();
            // Add files to task for upload
            var file1 = taskConvertOffice.AddFile(filesavepath);
            // Execute the task
            taskConvertOffice.Process();
            // Download the package files
            taskConvertOffice.DownloadFile("C:\\Users\\lucas\\Downloads");

            if (System.IO.File.Exists(filesavepath))
            {
                System.IO.File.Delete(filesavepath);
                return RedirectToAction(nameof(DOCpPDF));
            }

            return RedirectToAction(nameof(DOCpPDF));
        }
    }
}
