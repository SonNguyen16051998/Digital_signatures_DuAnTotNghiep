using Digital_Signatues.Helpers;
using Digital_Signatues.Models;
using Digital_Signatues.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.util;

namespace Digital_Signatues.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KySosController : Controller
    {
        private readonly IKySo _kyso;
        private readonly IHostingEnvironment _environment;
        public KySosController(IKySo kyso, IHostingEnvironment environment)
        {
            _kyso = kyso;
            _environment = environment;
        }
        /// <summary>
        /// ký thử
        /// </summary>
        /// <param name="kysotest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> sign(KySoTest kysotest)
        {
            kysotest.NgayKyTest = System.DateTime.Now;
            if(ModelState.IsValid)
            {
                if(await _kyso.AddKySoTest(kysotest)>0)
                {
                    string outputFile = Path.Combine(_environment.WebRootPath, "Filedaky");
                    string filePath = Path.Combine(outputFile, "TestA4_daky.pdf");
                    string fontPath = Path.Combine(_environment.WebRootPath, "Font", "ARIALUNI.TTF");
                    Certicate myCert = new Certicate(Path.Combine(_environment.WebRootPath, "Font", "chinhchu.pfx"), "chinhchu");
                    PDFSigner pdfs = new PDFSigner(kysotest.inputFile, filePath, myCert, fontPath);
                    var recJ = new RectangleJ((int)kysotest.x, (int)kysotest.y, (int)kysotest.img_w, (int)kysotest.img_h);
                    // string inputImg = @"https://firebasestorage.googleapis.com/v0/b/tot-nghiep-csharp.appspot.com/o/ck1.png?alt=media&token=a7200610-5600-43cd-a14c-a43fe17ce612&fbclid=IwAR29NnTmYY5qepYqO5s3x9iQ71y9LdB5Le5y0xeAWaUgI7fSUlGwUVXe48Y";
                    string inputImg = kysotest.imgSign;
                    var rectangle = new iTextSharp.text.Rectangle(recJ);
                    pdfs.SignImage("kí thử", "", "", inputImg, rectangle, kysotest.pageSign, "lý do", false);
                    PDFToImage.PdfToJpg(filePath, Path.Combine(_environment.WebRootPath, "ImgDaKy"));
                    return Ok(new
                    {
                        retCode=1,
                        retText="Ký thử thành công",
                        file = filePath
                    });
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Ky test thất bại",
                data = ""
            });
        }
    }
}
