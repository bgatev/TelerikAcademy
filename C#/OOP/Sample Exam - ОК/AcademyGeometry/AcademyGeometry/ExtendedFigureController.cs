using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryAPI
{
    public class ExtendedFigureController : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "vertex":
                case "segment":
                case "triangle":
                    {
                        base.ExecuteFigureCreationCommand(splitFigString);
                        break;
                    }
                case "circle":
                    {
                        Vector3D center = Vector3D.Parse(splitFigString[1]);
                        double radius = double.Parse(splitFigString[2]);
                        currentFigure = new Circle(center, radius);
                        break;
                    }
                case "cylinder":
                    {
                        Vector3D bottom = Vector3D.Parse(splitFigString[1]);
                        Vector3D top = Vector3D.Parse(splitFigString[2]);
                        double radius = double.Parse(splitFigString[3]);
                        currentFigure = new Cylinder(bottom, top, radius);
                        break;
                    }
            }

            this.EndCommandExecuted = false;
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "translate":
                case "rotate":
                case "scale":
                case "center":
                case "measure":
                    {
                        base.ExecuteFigureInstanceCommand(splitCommand);
                        break;
                    }
                case "area":
                    {
                        if (currentFigure is IAreaMeasurable && currentFigure != null) Console.WriteLine("{0:0.00}", (currentFigure as IAreaMeasurable).GetArea());
                        else Console.WriteLine("undefined");
                        break;
                    }
                case "volume":
                    {
                        if (currentFigure is IVolumeMeasurable && currentFigure != null) Console.WriteLine("{0:0.00}", (currentFigure as IVolumeMeasurable).GetVolume());
                        else Console.WriteLine("undefined");
                        break;
                    }
                case "normal":
                    {
                        if (currentFigure is IFlat && currentFigure != null) Console.WriteLine((currentFigure as IFlat).GetNormal());
                        else Console.WriteLine("undefined");
                        break;
                    }
            }
        }
    }
}
