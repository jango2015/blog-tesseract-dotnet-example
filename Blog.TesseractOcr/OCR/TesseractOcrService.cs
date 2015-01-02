using System;
using Tesseract;

namespace Blog.TesseractOcr.OCR
{
    class TesseractOcrService : IOcrService
    {
        
        /*
         *  Pfad des entpackten tessdata Ordners
         */
        private static readonly string DATA_PATH = @"E:\Temp\tessdata";
       
        private static readonly string LANGUAGE = "eng";

        private readonly TesseractEngine mOcrEngine;

        public TesseractOcrService()
        {
            mOcrEngine = new TesseractEngine(DATA_PATH, LANGUAGE, EngineMode.Default);
        }

        public string GetTextFromBitmap(System.Drawing.Bitmap bmp)
        {
            string result = String.Empty;

            using (Page page = mOcrEngine.Process(bmp))
            {
                result = page.GetText();
            }
            
            return result;
        }
    }
}
