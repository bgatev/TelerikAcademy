using System;

public class Size
{
    private double width, height;

  public Size(double figureWidth, double figureHeight)
  {
      this.width = figureWidth;
      this.height = figureHeight;
  }

  public double Width 
  { 
      get 
      {
          return this.width;
      }
  }

  public double Height
  {
      get
      {
          return this.height;
      }
  }
}

public class Program
{
    public static Size GetRotatedSize(Size figureSize, double figureAngle)
    {
        double newWidth = (Math.Abs(Math.Cos(figureAngle)) * figureSize.Width) + (Math.Abs(Math.Sin(figureAngle)) * figureSize.Height);
        double newHeight = (Math.Abs(Math.Sin(figureAngle)) * figureSize.Width) + (Math.Abs(Math.Cos(figureAngle)) * figureSize.Height);

        return new Size(newWidth, newHeight);
    }
}