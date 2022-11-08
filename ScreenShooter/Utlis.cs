
using System.Drawing;


namespace ScreenShooterApp
{
    internal class Utils
    {
        public static Rectangle GetScreenShotRectangle(Point a, Point b)
        {
            int imgWidth = b.X - a.X;
            int imgHeight = b.Y - a.Y;

            // if startKey pressed twice in same mouse position
            if (imgWidth == 0 || imgHeight == 0) return Rectangle.Empty;

            // normal shot from top left to bottom right
            if (imgWidth > 0 && imgHeight > 0) return new Rectangle(a.X, a.Y, imgWidth, imgHeight);

            Point temp = a;

            // upside down shot, from bottom right to top left
            if (imgWidth < 0 && imgHeight < 0)
            {
                a = b;
                b = temp;
            }
            // reversed horizontal shot, from top right to bottom left
            else if (imgWidth < 0 && imgHeight > 0)
            {
                a.X = b.X;
                b.X = temp.X;

            }
            // reversed vertical shot, from bottom left to top right
            else if (imgWidth > 0 && imgHeight < 0)
            {
                a.Y = b.Y;
                b.Y = temp.Y;
            }

            imgWidth = b.X - a.X;
            imgHeight = b.Y - a.Y;

            return new Rectangle(a.X, a.Y, imgWidth, imgHeight);
        }
    }
}
