namespace Computers
{
    using System;
    using C = System.Console;

    public class VideoCard : IVideoCard
    {
        public VideoCard()
        {
        }

        public bool IsMonochrome { get; set; }

        public void Draw(string a)
        {
            if (this.IsMonochrome)
            {
                C.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                C.ForegroundColor = ConsoleColor.Green;
            }

            C.WriteLine(a);
            C.ResetColor();
        }
    }
}
