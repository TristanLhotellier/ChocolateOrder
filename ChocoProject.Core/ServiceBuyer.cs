using ChocoProject.Core;
using FileInteraction;
using ListManager;
using Logs;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                              " \n Ajouter un article dans votre : Tapez le numéro de l'article voulu \n" +
                "Finaliser votre commande : Tapez F\n" +
                "Voir le prix de votre panier : Tapez P\n" +
                "Quitter : Tapez Q \n");
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
                    Logger.WriteLog((AjouterArticlePanier(number) ? "Réussi" : "Echec") + " : Ajout d'un article dans le panier (index : "+number+")",false);
                }
                else
                {
                    switch (choice)
                    {
                        case "F":
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

        public bool AjouterArticlePanier(int index)
        {
            return PurchasedArticleService.AddArticleOnBasket(BuyerConnected, index);
        }
    
}