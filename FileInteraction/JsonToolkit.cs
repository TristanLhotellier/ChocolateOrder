namespace FileInteraction;
using Models;
using Newtonsoft.Json;

public class JsonToolkit
{
    public List<Buyer> Deserialize(string filepath)
        {
            // Lit le contenu du fichier JSON.
            string json = File.ReadAllText(filepath);
            // Désérialise le contenu JSON en une liste d'objets Buyer.
            return JsonConvert.DeserializeObject<List<Buyer>>(json)!;
        }

        public string Serialize(List<Buyer> json)
        {
            // Sérialise une liste d'objets Buyer en une chaîne JSON.
            return JsonConvert.SerializeObject(json);
        }

        public List<Administrator> DeserializeAdministrator(string filepath)
        {
            // Lit le contenu du fichier JSON.
            string json = File.ReadAllText(filepath);
            // Désérialise le contenu JSON en une liste d'objets Administrator.
            return JsonConvert.DeserializeObject<List<Administrator>>(json)!;
        }

        public string SerializeAdministrator(List<Administrator> json)
        {
            // Sérialise une liste d'objets Administrator en une chaîne JSON.
            return JsonConvert.SerializeObject(json);
        }

        public List<Article> DeserializeArticles(string filepath)
        {
            // Lit le contenu du fichier JSON.
            string json = File.ReadAllText(filepath);
            // Désérialise le contenu JSON en une liste d'objets Article.
            return JsonConvert.DeserializeObject<List<Article>>(json)!;
        }

        public string SerializeArticles(List<Article> json)
        {
            // Sérialise une liste d'objets Article en une chaîne JSON.
            return JsonConvert.SerializeObject(json);
        }

        public List<PurchasedArticle> DeserializeArticlesPurchased(string filepath)
        {
            // Lit le contenu du fichier JSON.
            string json = File.ReadAllText(filepath);
            // Désérialise le contenu JSON en une liste d'objets ArticlesPurchased.
            return JsonConvert.DeserializeObject<List<PurchasedArticle>>(json)!;
        }

        public string SerializeArticlesPurchased(List<PurchasedArticle> json)
        {
            // Sérialise une liste d'objets ArticlesPurchased en une chaîne JSON.
            return JsonConvert.SerializeObject(json);
        }
}