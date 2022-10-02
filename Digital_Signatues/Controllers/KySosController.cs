using Digital_Signatues.Helpers;
using Digital_Signatues.Models;
using Digital_Signatues.Models.ViewPost;
using Digital_Signatues.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        /// <param name="signs"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SignTest([FromBody] PostSign signs)
        {
            if (ModelState.IsValid)
            {
                string fileName="";
                foreach (var item in signs.PostPositionSigns)
                {
                    string outputFile ="";
                    string inputNewFile = "";
                    string fieldName = "";
                    string name = Path.GetFileNameWithoutExtension(signs.inputFile);
                    string fontPath = Path.Combine(_environment.WebRootPath, "Font", "ARIALUNI.TTF");
                    Certicate myCert = new Certicate(Path.Combine(_environment.WebRootPath, "Font", "chinhchu.pfx"), "chinhchu");
                    PDFSigner pdfs = new PDFSigner();
                    for(int i = 0;i<1000;i++)
                    {
                        fileName = name + "_" + i + "_daky.pdf";
                        fieldName = "filedName_" + i;
                        outputFile = Path.Combine(_environment.WebRootPath, "Filedaky") + @"\" + name + "_" + i + "_daky.pdf";
                        if(!System.IO.File.Exists(outputFile))
                        {
                            inputNewFile = Path.Combine(_environment.WebRootPath, "Filedaky") + @"\" + name + "_" + (i - 1) + "_daky.pdf";
                            break;
                        }
                    }
                    if (System.IO.File.Exists(inputNewFile))
                    {
                        pdfs = new PDFSigner(inputNewFile, outputFile, myCert, fontPath);
                    }
                    else
                    {
                        pdfs = new PDFSigner(signs.inputFile, outputFile, myCert, fontPath);
                    }
                    if(!string.IsNullOrEmpty(item.textSign))
                    {
                        var rectangle = new iTextSharp.text.Rectangle((int)item.x,(int) item.y);
                        pdfs.SignText("kí thử", "", "", item.textSign, rectangle, 1, fieldName);
                    }
                    else
                    {
                        var recJ = new RectangleJ((int)item.x, (int)item.y, (int)item.img_w, (int)item.img_h);

                        string inputImg = item.imgSign;
                        var rectangle = new iTextSharp.text.Rectangle(recJ);
                        pdfs.SignImage("kí thử", "", "", inputImg, rectangle, item.pageSign, fieldName, false);
                    }
                }
                return Ok(new
                {
                    retCode = 1,
                    retText = "Ký thử thành công",
                    data = Path.Combine("Filedaky", fileName)
                });
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
