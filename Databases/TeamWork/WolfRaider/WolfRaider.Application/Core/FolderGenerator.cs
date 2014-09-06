namespace WolfRaider.Application.Core
{
    using System.IO;

    using WolfRaider.Application.Core.Contracts;
    using WolfRaider.Common.Config;

    public class FolderGenerator : IFolderGenerator
    {
        public void CreateXMLFolder()
        {
            if (!Directory.Exists(Folders.XmlFolder))
            {
                Directory.CreateDirectory(Folders.XmlFolder);
            }
        }

        public void CreateJsonFolder()
        {
            if (!Directory.Exists(Folders.JsonFolder))
            {
                Directory.CreateDirectory(Folders.JsonFolder);
            }
        }

        public void CreateExcelFolder()
        {
            if (!Directory.Exists(Folders.ExcelFolder))
            {
                Directory.CreateDirectory(Folders.ExcelFolder);
            }
        }

        public void CreatePdfFolder()
        {
            if (!Directory.Exists(Folders.PdfFolder))
            {
                Directory.CreateDirectory(Folders.PdfFolder);
            }
        }
    }
}
