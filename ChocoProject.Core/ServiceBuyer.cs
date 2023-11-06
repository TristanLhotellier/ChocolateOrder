using FileInteraction;
using ListManager;
using Logs;
using Models;
using System.Configuration;

namespace ChocoProject.Core;

public class ServiceBuyer
{
    public FileWriter FileWriter = FileWriter.Instance;
        public JsonToolkit JsonTool = new JsonToolkit();
        public DisplayConsole DC = new DisplayConsole();
        public LogWriter Logger = new LogWriter();
        public string FilePathBuyer = ConfigurationManager.AppSettings["pathDB"] + "buyer.json";

        public Buyer BuyerConnected;
        public BaseModelList<Buyer> BuyerList = new BaseModelList<Buyer>();

        public ServiceArticle ArticleService = ServiceArticle.Instance;
        public ServicePurchasedArticle PurchasedArticleService = ServicePurchasedArticle.Instance;

        public ServiceBuyer()
        {
            Logger.WriteLog((LoadBuyerList() ? "Réussi" : "Echec") + " : Chargement de la liste des utilisateurs depuis la DB", false);
        }

        public bool LoadBuyerList()
        {
            return BuyerList.setlList(JsonTool.Deserialize(FilePathBuyer));
        }

        public bool saveBuyerList()
        {
            _ = FileWriter.WriteToFile(FilePathBuyer, JsonTool.Serialize(BuyerList.GetList()));
            return true;
        }

        public bool formBuyer()
        {
            BuyerConnected = new Buyer();
            BuyerConnected.LastName = DC.inputLastNameBuyer();
            BuyerConnected.FirstName = DC.inputFirstNameBuyer();
            BuyerConnected.Phone = DC.inputTelBuyer();
            if (!BuyerExist())
            {
                BuyerList.Add(BuyerConnected);
            }
            Console.WriteLine(DC.PrintArticleList(ArticleService.ArticleList));
            return true;
        }

        public bool BuyerExist()
        {
            Buyer foundBuyer = BuyerList.GetList().Find(u => (u.LastName == BuyerConnected.LastName) && (u.FirstName == BuyerConnected.FirstName))!;
            if (foundBuyer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string BuyerChoice()
        {
            Console.WriteLine("Si vous voulez :" +
                              " \nAjouter un article dans votre panier : Tapez le numéro de l'article voulu \n" +
                "Valider la commande : V\n" +
                "Prix du panier : P\n" +
                "Quitter : Q \n");
            string choice = Console.ReadLine()!;
            return choice;
        }

        public bool BuyerMenu()
        {
            bool isFinish = false;
            while (!isFinish)
            {
                string choice = BuyerChoice();
                int number;
                if (int.TryParse(choice, out number))
                {
                    Logger.WriteLog((AddArticleBasket(number) ? "Réussi" : "Echec") + " : Ajout d'un article dans le panier (index : "+number+")",false);
                }
                else
                {
                    switch (choice)
                    {
                        case "V":
                            Console.WriteLine(PurchasedArticleService.validBasket(BuyerConnected));
                            break;
                        case "P":
                            Console.WriteLine("Montant de votre panier : "+PurchasedArticleService.PriceArticlesPurchasedList(PurchasedArticleService.PurchasedArticlesList)+"€");
                            break;
                        case "Q":
                            isFinish = true;
                            break;
                    }
                    
                }
            }
            return isFinish;
        }

        private bool AddArticleBasket(int index)
        {
            return PurchasedArticleService.AddArticleOnBasket(BuyerConnected, index);
        }
    
}