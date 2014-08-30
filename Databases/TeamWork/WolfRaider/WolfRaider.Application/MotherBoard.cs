using WolfRaider.Application.ApplicationGenerator;
using WolfRaider.Application.Contracts;

namespace WolfRaider.Application
{
    public class MotherBoard : IMotherBoard
    {
        private readonly AppGenerator appGenerator = new AppGenerator();


        public void GenerateApplicationFolders()
        {
            appGenerator.GenerateFolderStructure();
        }



    }
}
