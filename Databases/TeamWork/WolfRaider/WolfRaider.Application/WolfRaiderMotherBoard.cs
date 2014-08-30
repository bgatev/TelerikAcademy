using WolfRaider.Application.ApplicationGenerator;

namespace WolfRaider.Application
{
    public class WolfRaiderMotherBoard
    {
        private readonly AppGenerator appGenerator = new AppGenerator();


        public void GenerateApplicationFolders()
        {
            appGenerator.GenerateFolderStructure();
        }

    }
}
