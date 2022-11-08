using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ScreenShooterApp
{
    internal class PhotoShooter
    {
        private Bitmap capturedBitmap;
        private Point startPoint;

        public PhotoShooter()
        {
            this.startPoint = new Point(-1, -1); 
        }

        private bool EmptyPoint(Point p)
        {
            return p.X < 0 && p.Y < 0; 
        }
        public Bitmap GetPreviewImage(float picBoxWidth, float picBoxHeight)
        {
            if (capturedBitmap == null) return null;

            float scale = Math.Min(picBoxWidth / capturedBitmap.Width, picBoxHeight / capturedBitmap.Height);
            var scaleWidth = (int)(capturedBitmap.Width * scale);
            var scaleHeight = (int)(capturedBitmap.Height * scale);

            return new Bitmap(capturedBitmap, new Size(scaleWidth,scaleHeight));
        }

        public bool HasCaptureStarted()
        {
            return !EmptyPoint(startPoint);
        }

        public bool HasCaptureFinished()
        {
            return capturedBitmap != null;
        }

        public CaptureState CaptureScreenShot(Point receivedPoint)
        {
            if (capturedBitmap != null) Reset();
            if (EmptyPoint(startPoint))
            {
                startPoint = receivedPoint;
                return CaptureState.STARTED;
            }

            Rectangle rect = Utils.GetScreenShotRectangle(startPoint, receivedPoint);
            if (rect.IsEmpty) return CaptureState.INVALID;
   
            capturedBitmap = new Bitmap(Math.Abs(rect.Width), Math.Abs(rect.Height), PixelFormat.Format32bppArgb);
            Size bmpSize = new Size(Math.Abs(rect.Width), Math.Abs(rect.Height));
            Graphics g = Graphics.FromImage(capturedBitmap);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmpSize, CopyPixelOperation.SourceCopy);       
            g.Dispose();
            return CaptureState.CAPTURED;
        }

        public bool SaveScreenShot(String filename)
        {
            if (capturedBitmap == null) return false;
            try
            {
                capturedBitmap.Save(filename);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }      
        }

        public void Reset()
        {   
            this.startPoint = new Point(-1, -1);
            this.capturedBitmap = null;
        }

        public enum CaptureState
        {
           STARTED, CAPTURED, INVALID
        }
    }
}