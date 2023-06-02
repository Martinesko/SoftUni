using ProductShop.Data;
using System.Xml.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            string inputXml = File.ReadAllText("../../../Datasets/users.xml");

            Console.WriteLine(ImportUsers(context,inputXml));
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var Users = XDocument.Parse(inputXml).Root.Elements();

            foreach (var user in Users)
            {
                Console.WriteLine(user.Element("firstName").Value);
            }


            return "";
        }
    }
}