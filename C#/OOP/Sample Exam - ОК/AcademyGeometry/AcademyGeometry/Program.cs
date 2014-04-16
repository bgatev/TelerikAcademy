using System;
using System.Linq;
using GeometryAPI;
using System.Threading;

namespace AcademyGeometry
{
    class Program
    {
        private static FigureController GetFigureController()
        {
            //return new FigureController();
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            return new ExtendedFigureController();           
        }

        static void Main(string[] args)
        {
            //Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var figController = GetFigureController();

            int figCreationsCount = int.Parse(Console.ReadLine());
            int endCommandsCount = 0;

            while (endCommandsCount < figCreationsCount)
            {
                figController.ExecuteCommand(Console.ReadLine());
                if (figController.EndCommandExecuted)
                {
                    endCommandsCount++;
                }
            }
        }
    }
}
