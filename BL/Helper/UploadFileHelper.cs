using System.IO;
namespace BussinesEmployee.BL.Helper
{
    public static class UploadFileHelper
    {
        public static string SaveFile(IFormFile fileUrl, string folderPath)
        {
            try
            {
                var FilePath = Directory.GetCurrentDirectory() + "/wwwroot/Files" + folderPath;
                var fileName = Guid.NewGuid() + Path.GetFileName(fileUrl.FileName);
                var finalPath = Path.Combine(FilePath, fileName);

                using (var steam = new FileStream(finalPath, FileMode.Create))
                {
                    fileUrl.CopyTo(steam);
                }
                return fileName;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void RemoveFile(string removedFileName,string folderName)
        {
            if (!string.IsNullOrEmpty(removedFileName))
            {
                var path = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + Path.Combine(folderName, removedFileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
           
        }

       
    }
}
