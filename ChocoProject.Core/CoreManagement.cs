using Models;
using Logs;
using System.Configuration;
using FileInteraction;

namespace ChocoProject.Core;

public class CoreManagement
 {

        public FileWriter FileWriter = FileWriter.Instance;
        public JsonToolkit JsonTool = new JsonToolkit();
        public DisplayConsole DC = new DisplayConsole();

        public ServiceAdmin ServiceAdmin;
        public ServiceBuyer ServiceBuyer;
        public ServiceArticle ArticleService = ServiceArticle.Instance;
        public ServicePurchasedArticle ArticlesPurchasedService = ServicePurchasedArticle.Instance;
        
        public string FilePathArticlesPurchased = ConfigurationManager.AppSettings["pathDB"] + "articles_achetes.json";
        public string FilePathAdmin = ConfigurationManager.AppSettings["pathDB"] + "admin.json";
        public string FilePathBuyer = ConfigurationManager.AppSettings["pathDB"] + "buyer.json";
        public string FilePathArticle = ConfigurationManager.AppSettings["pathDB"] + "articles.json";

        public List<PurchasedArticle> PurchasedArticlesService = new List<PurchasedArticle>();
        public LogWriter Logger = new LogWriter();

        public CoreManagement() 
        {
            filesExistsAndCreate();
            loadDB();
            Console.Clear();
            switch (ConnectChoice())
            {
                case 1:
                    Logger.WriteLog((ServiceAdmin!.formAdmin() ? "Connexion de l'administrateur" : "Inscription de l'administrateur"), true);
                    ServiceAdmin!.AdminMenu();
                    break;
                case 2:
                    ServiceBuyer!.formBuyer();
                    ServiceBuyer!.BuyerMenu();
                break;
            }
            saveAll();
        }


        public int ConnectChoice()
        {
            Console.WriteLine("Connexion en tant que : \n 1 : Administrateur \n 2 : Utilisateur \n 3 : Quitter");
            int choice = int.Parse(Console.ReadLine()!);
            return choice;
        }

        public bool filesExistsAndCreate()
        {
            if (!this.FileWriter.FileExiste(FilePathAdmin))
            {
                Logger.WriteLog((FileWriter.CreateFile(FilePathAdmin) ? "Réussi" : "Echec") + " : Création du fichier de sauvegarde de la liste des administrateurs", true);
            }

            if (!this.FileWriter.FileExiste(FilePathBuyer))
            {
                Logger.WriteLog((FileWriter.CreateFile(FilePathBuyer) ? "Réussi" : "Echec") + " : Création du fichier de sauvegarde de la liste des utilisateurs", true);
            }

            if (!this.FileWriter.FileExiste(FilePathArticle))
            {
                Logger.WriteLog((FileWriter.CreateFile(FilePathArticle) ? "Réussi" : "Echec") + " : Création du fichier de sauvegarde de la liste des articles", true);
            }

            if (!this.FileWriter.FileExiste(FilePathArticlesPurchased))
            {
                Logger.WriteLog((FileWriter.CreateFile(FilePathArticlesPurchased) ? "Réussi" : "Echec") + " : Création du fichier de sauvegarde des articles achetés", true);
            }

            return true;
        }


        public bool loadDB()
        {
            ServiceAdmin = new ServiceAdmin();
            ServiceBuyer = new ServiceBuyer();
            ArticleService.LoadArticleList();
            ArticlesPurchasedService.LoadArticlesPurchasedList();
            return true;
        }

        public bool saveAll()
        {
            Logger.WriteLog((ServiceAdmin.SaveAdminList() ? "Réussi" : "Echec")+" : Sauvegarde administrateurs",true);
            Logger.WriteLog((ServiceBuyer.saveBuyerList()? "Réussi" : "Echec")+" : Sauvegarde utilisateurs", true);
            Logger.WriteLog((ArticleService.SaveArticleList() ? "Réussi" : "Echec") + " : Sauvegarde articles", true);
            Logger.WriteLog((ArticlesPurchasedService.SaveArticlesPurchasedList() ? "Réussi" : "Echec") + " : Sauvegarde articles achetés", true);

            return true;
        }
    }