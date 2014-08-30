using System.IO;
using WolfRaider.Common.Config;

namespace WolfRaider.Application.ApplicationGenerator
{
    public class AppGenerator
    {
        public void GenerateFolderStructure()
        {
            this.CreateJsonFolder();
            this.CreateExcelFolder();
        }

        private void CreateJsonFolder()
        {
            if (!Directory.Exists(Folders.JsonFolder))
            {
                Directory.CreateDirectory(Folders.JsonFolder);
            }
        }

        private void CreateExcelFolder()
        {
            if (!Directory.Exists(Folders.ExcelFolder))
            {
                Directory.CreateDirectory(Folders.ExcelFolder);
            }
        }
    }
}
