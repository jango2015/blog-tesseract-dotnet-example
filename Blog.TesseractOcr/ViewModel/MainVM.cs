using Blog.TesseractOcr.OCR;
using RS.WPF.Framework;
using RS.WPF.Framework.Dialog;
using System;
using System.Drawing;

namespace Blog.TesseractOcr.ViewModel
{
    class MainVM : ViewModelBase
    {

        private readonly IOcrService mOCRService;
        private readonly IFileDialogService mFileDialogService;
        private readonly BindableCommand mOpenImgCmd;

        private Bitmap mImage;
        private string mText;

        public MainVM()
        {
            mOCRService = new TesseractOcrService();
            mFileDialogService = new FileDialogService();
            mOpenImgCmd = new BindableCommand(OnOpenImageBtnClick);
        }

        private void OnOpenImageBtnClick()
        {
           string file = mFileDialogService.OpenFileDialog(null,
               new string[] { ".bmp", ".jpg" });
           if (file == String.Empty)
               return;
           LoadImage(file);
        }


        private void LoadImage(string file)
        {
           mImage = new Bitmap(file);
           RaisePropertyChanged(() => Image); // Dem View mitteilen dass sich das Bild geändert hat
           ProcessImage();
        }

  
        private void ProcessImage()
        {
           mText = mOCRService.GetTextFromBitmap(mImage);
           RaisePropertyChanged(() => Text); // Dem View mitteilen dass sich der Text geändert hat
        }


        /*
         *      PROPERTIES
         */
        public BindableCommand OpenImgCmd
        {
            get { return mOpenImgCmd; }
        }

        public Bitmap Image
        {
            get { return mImage; }
        }

        public string Text
        {
            get { return mText; }
            set { mText = value; }
        }
    }
}
