using Digital_Signatues.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using System;
using System.IO;
using System.Text;

namespace Digital_Signatues.Helpers
{
    public class PDFSigner
    {
        private string InputPDF = "";
        private string OutputPDF = "";
        private Certicate Cert;
        private string FontPath = "";
        public PDFSigner(string input, string output)
        {
            this.InputPDF = input;
            this.OutputPDF = output;
        }

        public PDFSigner(string input, string output, Certicate cert)
        {
            this.InputPDF = input;
            this.OutputPDF = output;
            this.Cert = cert;
        }
        public PDFSigner(string input, string output, Certicate cert, string fontPath)
        {
            this.InputPDF = input;
            this.OutputPDF = output;
            this.Cert = cert;
            this.FontPath = fontPath;
        }

        public void Verify()
        {
        }
        public void SignImage(string sigReason, string sigContact, string sigLocation, string imageFilePath,
         Rectangle rectangle, int page, string fieldName, bool flagKyHethong)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            IExternalSignature externalSignature = new PrivateKeySignature(this.Cert.Akp, DigestAlgorithms.SHA512);
            PdfReader.unethicalreading = true;
            PdfReader reader = new PdfReader(this.InputPDF);
            var output = new FileStream(this.OutputPDF, FileMode.Create, FileAccess.Write);
            PdfStamper Stamper = PdfStamper.CreateSignature(reader, output, '\0', null, true);

            //PdfStamper stamper = PdfStamper.CreateSignature(reader, fout, '\0', true);
            PdfSignatureAppearance appearance = Stamper.SignatureAppearance;
            appearance.Reason = sigReason;
            appearance.Location = sigLocation;
            appearance.Contact = sigContact;
            appearance.SignDate = DateTime.Now;

            appearance.Acro6Layers = true; // không hiển thị dấu valid

            //appearance.SetVisibleSignature(rectangle, page, "Signature");
            appearance.SetVisibleSignature(rectangle, page, fieldName);


            Font NormalFont = FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLUE);
            BaseFont bf = BaseFont.CreateFont(this.FontPath, BaseFont.IDENTITY_H, true);
            appearance.Layer2Font = new iTextSharp.text.Font(bf, (float)11.5, Font.NORMAL, BaseColor.BLUE);

            if (flagKyHethong)
            {
                //imageFilePath= Server.Map ""
                appearance.SignatureGraphic = Image.GetInstance(imageFilePath);
                appearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;
                //appearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.NAME_AND_DESCRIPTION;
                //appearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.GRAPHIC_AND_DESCRIPTION;
            }
            else
            {
                appearance.SignatureGraphic = Image.GetInstance(imageFilePath);
                appearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.GRAPHIC;
            }
            //appearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.GRAPHIC;
            //appearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.GRAPHIC_AND_DESCRIPTION;

            //signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;


            appearance.CertificationLevel = PdfSignatureAppearance.NOT_CERTIFIED; // cho phép ký nhiều chữ ký
                                                                                  //appearance.CertificationLevel = PdfSignatureAppearance.CERTIFIED_FORM_FILLING_AND_ANNOTATIONS; // ký và khóa nội dung, sẽ bể những chữ ký có trước
                                                                                  //appearance.CertificationLevel
            /*
            appearance.setCertificationLevel(PdfSignatureAppearance.CERTIFIED_NO_CHANGES_ALLOWED);

            field.put(PdfName.LOCK, stamper.getWriter().addToBody(new PdfSigLockDictionary(LockPermissions.NO_CHANGES_ALLOWED)).getIndirectReference());
            field.setFlags(PdfAnnotation.FLAGS_PRINT);
            field.setPage(1);
            field.setWidget(new Rectangle(150, 250, 300, 401), PdfAnnotation.HIGHLIGHT_INVERT);
            stamper.addAnnotation(field, 1);
            */

            /*Utility.WriteFileError("Kiem loi Cert");
            if (this.Cert.ExternalSignature == null)
            {
                Utility.WriteFileError("this.Cert.ExternalSignature null");
            }
            if (this.Cert.Chain.Count == 0)
            {
                Utility.WriteFileError("this.Cert.Chain null");
            }*/
            MakeSignature.SignDetached(appearance, externalSignature, this.Cert.Chain, null, null, null, 0, CryptoStandard.CMS);
            Stamper.Close();
            reader.Close();
        }
    }
}
