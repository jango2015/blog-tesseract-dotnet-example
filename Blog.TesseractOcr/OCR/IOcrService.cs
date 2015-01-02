
namespace Blog.TesseractOcr.OCR
{
    interface IOcrService
    {
        string GetTextFromBitmap(System.Drawing.Bitmap bmp);
    }
}
