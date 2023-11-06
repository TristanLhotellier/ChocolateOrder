using System.Configuration;
using FileInteraction;
using ListManager;
using Models;

namespace ChocoProject.Core;

public class ServiceArticle : InterfaceServiceArticle
{
    public FileWriter FileWriter = FileWriter.Instance;
    public JsonToolkit JsonTool = new JsonToolkit();
    public DisplayConsole DC = new DisplayConsole();

        private static ServiceArticle instance = null;
        private static readonly object lockObject = new object();

        public string FilePathArticle = ConfigurationManager.AppSettings["pathDB"] + "articles.json";

        public BaseModelList<Article> ArticleList = new BaseModelList<Article>();
        public static ServiceArticle Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ServiceArticle();
                    }
                    return instance;
                }
            }
        }

        private ServiceArticle() { }
        public bool LoadArticleList()
        {
            // Charge la liste d'articles en utilisant la méthode DeserializeArticles de JsonTool.
            return ArticleList.setlList(JsonTool.DeserializeArticles(FilePathArticle));
        }

        public bool SaveArticleList()
        {
            // Sérialise la liste d'articles en utilisant la méthode SerializeArticles de JsonTool,
            // puis écrit le résultat dans un fichier à l'emplacement FilePathArticle en utilisant FileWriter.
            return FileWriter.WriteToFile(FilePathArticle, JsonTool.SerializeArticles(ArticleList.GetList()));
        }

        public bool formArticle()
        {
            // Crée un nouvel objet Article et initialise ses propriétés en demandant à l'utilisateur.
            Article Article = new Article();
            Article.Reference = DC.InputReferenceArticle();
            Article.Price = DC.InputPriceArticle();

            // Vérifie si un article avec la même référence existe déjà dans la liste.
            if (FindArticleByReference(Article.Reference) == null)
            {
                // Ajoute l'article à la liste d'articles.
                ArticleList.Add(Article);
                return true; // L'ajout a réussi.
            }
            return false; // L'article existe déjà.
        }

        public Article FindArticleByReference(string Reference)
        {
            Article foundArticle = null;
            if (ArticleList.GetList() != null)
            {
                // Recherche l'article dans la liste par sa référence.
                foundArticle = ArticleList.GetList().Find(u => u.Reference == Reference)!;
            }
            return foundArticle;
        }

        public string ArticleListToString()
        {
            // Utilise la méthode PrintArticleList d'DC pour convertir la liste d'articles en une chaîne lisible.
            return DC.PrintArticleList(ArticleList);
        }


    }