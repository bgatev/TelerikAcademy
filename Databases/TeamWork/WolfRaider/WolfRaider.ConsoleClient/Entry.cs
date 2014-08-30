using WolfRaider.Application;
using WolfRaider.Application.Contracts;

namespace WolfRaider.ConsoleClient
{
    internal static class Entry
    {
        internal static void Main()
        {
            IMotherBoard motherBoard = new MotherBoard();
            var gui = new GraphicalUserInterface(motherBoard);
            gui.Start();
        }
    }
}
