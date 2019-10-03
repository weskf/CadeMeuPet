using System.Configuration;

namespace CadeMeuPet.MVC.Util
{
    public class UrlPath
    {
        public string RetornaUrlPet(int AnimalId)
        {
            string url = ConfigurationManager.AppSettings["UrlImagens"];
            string urlPath = url + AnimalId +"/";
            return urlPath;
        }
    }
}