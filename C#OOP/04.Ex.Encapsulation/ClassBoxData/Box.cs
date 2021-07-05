using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const string VALIDATE_EXCEPTION = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                Validation(value, nameof(Length));
                length = value;
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                Validation(value, nameof(Width));
                width = value;
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                Validation(value, nameof(Height));
                height = value;
            }
        }
        public double SurfaceArea()
        {
            return (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
        }
        public double LateralSurfaceArea()
        {
            return (2 * Length * Height) + (2 * Width * Height);
        }
        public double Volume()
        {
            return Length * Width * Height;
        }
        private void Validation(double value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(VALIDATE_EXCEPTION,parameterName));
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}")
                .AppendLine($"Volume - {Volume():F2}");
            return sb.ToString().TrimEnd();
        }
    }
}
