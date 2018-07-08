using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Drawing;

namespace G_Clinic
{
    public sealed class Shape
    {
        #region " Enumarations "

        [Flags()]
        public enum Corner : int
        {
            None = 0,
            TopLeft = 1,
            TopRight = 2,
            BottomRight = 4,
            BottomLeft = 8
        };

        #endregion

        #region " Methods "

        [DebuggerHidden()]
        private Shape()
        {
        }

        /// <summary>
        /// Rounds the corners of a rectangle and returns the graphics path.
        /// </summary>
        /// <param name="rect">A rectangle whose corners should be rounded.</param>
        /// <param name="radius">The radius of the rounded corners. This value should be
        /// bigger than or equal to 0 and less or equal to the half of the smallest value
        /// of the rectangle’s side.</param>
        /// <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value
        /// can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
        [DebuggerHidden()]
        public static System.Drawing.Drawing2D.GraphicsPath RoundedRectangle(RectangleF rect, float radius, Corner exclude)
        {

            //If radius is less than zero,
            //throw an ArgumentException.
            if (radius < 0.0F)
            {
                throw new ArgumentException("Invalid argument. The value cannot be negativ.", "radius");
            }

            //If the rectangle object is empty,
            //than throw an ArgumentException.
            if (rect.IsEmpty)
            {
                throw new ArgumentException("Invalid argument. The rectangle cannot be empty.", "rect");
            }

            //Return-rounded rectangle path.
            return Shape.GetPath(rect.X, rect.Y, rect.Width, rect.Height, radius, exclude);

        }

        /// <summary>
        /// Rounds the corners of a rectangle and returns the graphics path.
        /// </summary>
        /// <param name="rect">A rectangle whose corners should be rounded.</param>
        /// <param name="radius">The radius of the rounded corners. This value should be
        /// bigger than or equal to 0 and less or equal to the half of the smallest value
        /// of the rectangle’s side.</param>
        /// <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value
        /// can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
        [DebuggerHidden()]
        public static System.Drawing.Drawing2D.GraphicsPath RoundedRectangle(Rectangle rect, int radius, Corner exclude)
        {

            //If radius is less than zero,
            //throw an ArgumentException.
            if (radius < 0.0F)
            {
                throw new ArgumentException("Invalid argument. The value cannot be negativ.", "radius");
            }

            //If the rectangle object is empty,
            //than throw an ArgumentException.
            if (rect.IsEmpty)
            {
                throw new ArgumentException("Invalid argument. The rectangle cannot be empty.", "rect");
            }

            //Return-rounded rectangle path.
            return Shape.GetPath(Convert.ToSingle(rect.X), Convert.ToSingle(rect.Y), Convert.ToSingle(rect.Width), Convert.ToSingle(rect.Height), Convert.ToSingle(radius), exclude);

        }

        /// <summary>
        /// Creats and returns a rounded corner region.
        /// </summary>
        /// <param name="rSize">The size of the region.</param>
        /// <param name="radius">The radius of the rounded corners. This value should be
        /// bigger than or equal to 0 and less or equal to the half of the smallest value
        /// of the region’s side.</param>
        /// <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value
        /// can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
        [DebuggerHidden()]
        public static Region RoundedRegion(SizeF rSize, float radius, Corner exclude)
        {

            //If radius is less than zero,
            //throw an ArgumentException.
            if (radius < 0.0F)
            {
                throw new ArgumentException("Invalid argument. The value cannot be negativ.", "radius");
            }

            //If the rectangle object is empty,
            //than throw an ArgumentException.
            if (rSize.IsEmpty)
            {
                throw new ArgumentException("Invalid argument. The rectangle cannot be empty.", "rSize");
            }

            //Return-rounded rectangle region.
            return Shape.GetRegion(0.0F, 0.0F, rSize.Width, rSize.Height, radius, exclude);

        }

        /// <summary>
        /// Creats and returns a rounded corner region.
        /// </summary>
        /// <param name="rSize">The size of the region.</param>
        /// <param name="radius">The radius of the rounded corners. This value should be
        /// bigger than or equal to 0 and less or equal to the half of the smallest value
        /// of the region’s side.</param>
        /// <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value
        /// can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
        [DebuggerHidden()]
        public static Region RoundedRegion(Size rSize, int radius, Corner exclude)
        {

            //If radius is less than zero,
            //throw an ArgumentException.
            if (radius < 0.0F)
            {
                throw new ArgumentException("Invalid argument. The value cannot be negativ.", "radius");
            }

            //If the rectangle object is empty,
            //than throw an ArgumentException.
            if (rSize.IsEmpty)
            {
                throw new ArgumentException("Invalid argument. The rectangle cannot be empty.", "rSize");
            }

            //Return-rounded rectangle region.
            return Shape.GetRegion(0.0F, 0.0F, Convert.ToSingle(rSize.Width), Convert.ToSingle(rSize.Height), Convert.ToSingle(radius), exclude);

        }

        /// <summary>
        /// Creats and returns a rounded corner region.
        /// </summary>
        /// <param name="rect">The rectangle of the region.</param>
        /// <param name="radius">The radius of the rounded corners. This value should be
        /// bigger than or equal to 0 and less or equal to the half of the smallest value
        /// of the region’s side.</param>
        /// <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value
        /// can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
        [DebuggerHidden()]
        public static Region RoundedRegion(RectangleF rect, float radius, Corner exclude)
        {

            //If radius is less than zero,
            //throw an ArgumentException.
            if (radius < 0.0F)
            {
                throw new ArgumentException("Invalid argument. The value cannot be negativ.", "radius");
            }

            //If the rectangle object is empty,
            //than throw an ArgumentException.
            if (rect.IsEmpty)
            {
                throw new ArgumentException("Invalid argument. The rectangle cannot be empty.", "rect");
            }

            //Return-rounded rectangle region.
            return Shape.GetRegion(rect.X, rect.Y, rect.Width, rect.Height, radius, exclude);

        }

        /// <summary>
        /// Creats and returns a rounded corner region.
        /// </summary>
        /// <param name="rect">The rectangle of the region.</param>
        /// <param name="radius">The radius of the rounded corners. This value should be
        /// bigger than or equal to 0 and less or equal to the half of the smallest value
        /// of the region’s side.</param>
        /// <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value
        /// can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
        [DebuggerHidden()]
        public static Region RoundedRegion(Rectangle rect, int radius, Corner exclude)
        {

            //If radius is less than zero,
            //throw an ArgumentException.
            if (radius < 0.0F)
            {
                throw new ArgumentException("Invalid argument. The value cannot be negativ.", "radius");
            }

            //If the rectangle object is empty,
            //than throw an ArgumentException.
            if (rect.IsEmpty)
            {
                throw new ArgumentException("Invalid argument. The rectangle cannot be empty.", "rect");
            }

            //Return-rounded rectangle region.
            return Shape.GetRegion(Convert.ToSingle(rect.X), Convert.ToSingle(rect.Y), Convert.ToSingle(rect.Width), Convert.ToSingle(rect.Height), Convert.ToSingle(radius), exclude);

        }

        [DebuggerHidden()]
        private static GraphicsPath GetPath(float x, float y, float width, float height, float r, Corner exclude)
        {

            GraphicsPath path = new GraphicsPath();
            //If radius is equal to zero,
            //than return a simple rectangle path.
            if (r == 0.0F)
            {
                path.AddRectangle(new RectangleF(x, y, width, height));
                return path;
            }

            //Small corner square-rectangles width
            float w = r + r;
            //If 'w' is bigger than the smallest value of the whidth/height,
            //than assign the smallest value of the whidth/height to 'w'.
            if (height < width)
            {
                if (w > height)
                {
                    w = height;
                }
            }
            else
            {
                if (w > width)
                {
                    w = width;
                }
            }
            path.StartFigure();
            //Set top-left corner.
            if ((exclude & Corner.TopLeft) != Corner.TopLeft)
            {
                path.AddLine(x, y + r, x, y + r);
                path.AddArc(x, y, w, w, 180.0F, 90.0F);
                path.AddLine(x + r, y, x + r, y);
            }
            else
            {
                path.AddLine(x, y, x, y);
            }
            //Set top-right corner.
            if ((exclude & Corner.TopRight) != Corner.TopRight)
            {
                path.AddLine(x + width - r, y, x + width - r, y);
                path.AddArc(x + width - w, y, w, w, 270.0F, 90.0F);
                path.AddLine(x + width, y + r, x + width, y + r);
            }
            else
            {
                path.AddLine(x + width, y, x + width, y);
            }
            //Set bottom-right corner.
            if ((exclude & Corner.BottomRight) != Corner.BottomRight)
            {
                path.AddLine(x + width, y + height - r, x + width, y + height - r);
                path.AddArc(x + width - w, y + height - w, w, w, 0.0F, 90.0F);
                path.AddLine(x + width - r, y + height, x + width - r, y + height);
            }
            else
            {
                path.AddLine(x + width, y + height, x + width, y + height);
            }
            //Set bottom-left corner.
            if ((exclude & Corner.BottomLeft) != Corner.BottomLeft)
            {
                path.AddLine(x + r, y + height, x + r, y + height);
                path.AddArc(x, y + height - w, w, w, 90.0F, 90.0F);
                path.AddLine(x, y + height - r, x, y + height - r);
            }
            else
            {
                path.AddLine(x, y + height, x, y + height);
            }
            path.CloseAllFigures();
            return path;

        }

        [DebuggerHidden()]
        private static Region GetRegion(float x, float y, float width, float height, float r, Corner exclude)
        {

            GraphicsPath path = new GraphicsPath();
            //If radius is equal to zero,
            //than return a simple rectangle region.
            if (r == 0.0F)
            {
                path.AddRectangle(new RectangleF(x, y, width, height));
                return new Region(path);
            }

            //Small corner square-rectangles width
            float w = r + r;
            //If 'w' is bigger than the smallest value of the whidth/height,
            //than assign the smallest value of the whidth/height to 'w'.
            if (height < width)
            {
                if (w > height)
                {
                    w = height;
                }
            }
            else
            {
                if (w > width)
                {
                    w = width;
                }
            }
            path.StartFigure();
            //Set top-left corner.
            if ((exclude & Corner.TopLeft) != Corner.TopLeft)
            {
                path.AddLine(x, y + r, x, y + r);
                path.AddArc(x, y, w - 1.0F, w - 1.0F, 180.0F, 90.0F);
                path.AddLine(x + r, y, x + r, y);
            }
            else
            {
                path.AddLine(x, y, x, y);
            }
            //Set top-right corner.
            if ((exclude & Corner.TopRight) != Corner.TopRight)
            {
                path.AddLine(x + width - r, y, x + width - r, y);
                path.AddArc(x + width - w, y, w - 1.0F, w - 1.0F, 270.0F, 90.0F);
                path.AddLine(x + width, y + r, x + width, y + r);
            }
            else
            {
                path.AddLine(x + width, y, x + width, y);
            }
            //Set bottom-right corner.
            if ((exclude & Corner.BottomRight) != Corner.BottomRight)
            {
                path.AddLine(x + width, y + height - r - 1.0F, x + width, y + height - r - 1.0F);
                path.AddArc(x + width - w, y + height - w, w - 1.0F, w - 1.0F, 0.0F, 90.0F);
                path.AddLine(x + width - r - 1.0F, y + height, x + width - r - 1.0F, y + height);
            }
            else
            {
                path.AddLine(x + width, y + height, x + width, y + height);
            }
            //Set bottom-left corner.
            if ((exclude & Corner.BottomLeft) != Corner.BottomLeft)
            {
                path.AddLine(x + r + 1.0F, y + height, x + r + 1.0F, y + height);
                path.AddArc(x, y + height - w, w - 1.0F, w - 1.0F, 90.0F, 90.0F);
                path.AddLine(x, y + height - r - 1.0F, x, y + height - r - 1.0F);
            }
            else
            {
                path.AddLine(x, y + height, x, y + height);
            }
            path.CloseAllFigures();
            return new Region(path);

        }

        #endregion
    }
}
