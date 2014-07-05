namespace Telerik.ILS.Common
{
    using System;
    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Core;
    using log4net.Layout;
    
    /// <summary>
    /// This is The Main Program
    /// </summary>
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        
        /// <summary>
        /// main method
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("This is Main Program. For GitHub usage please see: https://github.com/bgatev/Hangman-5");
            Console.WriteLine("Both files are inspected with StyleCop");
            Console.WriteLine("For JustDecompile usage please see: JustDecompile.jpg");
            Console.WriteLine("For SandCastle usage please see: Documentation.chm");
            Console.WriteLine("For Obfustication I used Eazfuscator.NET. Please see in Release Folder");

            var fileAppender = new FileAppender();
            fileAppender.File = "mylog.txt";
            fileAppender.AppendToFile = true;
            fileAppender.Threshold = Level.Warn;
            fileAppender.Layout = new SimpleLayout();
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(fileAppender);
            Log.Info("My info message");
            Log.Debug("My debug message");
            Log.Error("My error message");
        }
    }
}
