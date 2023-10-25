using Microsoft.AspNetCore.Mvc;

namespace WebApplication9.Controllers
{
    public class FileController : Controller
    {
        public IActionResult DownloadFile()
        {
            return View("./Views/Download.cshtml");
        }

        [HttpPost]
        public IActionResult Download(string firstName, string lastName, string fileName)
        {
            string userData = $"First Name: {firstName}, Last Name: {lastName}";
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "UserFiles");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, fileName + ".txt");
            string contentType = "text/plain";

            System.IO.File.WriteAllText(filePath, userData);

            return File(System.IO.File.ReadAllBytes(filePath), contentType, fileName + ".txt");
        }

        public IActionResult DownloadUserAndProducts(string firstName, string lastName, List<string> products)
        {
            string userInformation = $"User Information: First Name - {firstName}, Last Name - {lastName}";

            string content = userInformation + "\n\nProducts:\n";

            foreach (var product in products)
            {
                content += product + "\n";
            }

            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "UserAndProductsFiles");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string fileName = $"{firstName}_{lastName}_Products.txt";
            string filePath = Path.Combine(directoryPath, fileName);
            string contentType = "text/plain";

            System.IO.File.WriteAllText(filePath, content);

            return File(System.IO.File.ReadAllBytes(filePath), contentType, fileName);
        }
    }
}
