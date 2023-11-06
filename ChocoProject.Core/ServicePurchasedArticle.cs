using FileInteraction;
using Models;
using System.Configuration;
using System.Text;

namespace ChocoProject.Core;

public class ServicePurchasedArticle
{

        private static ServicePurchasedArticle instance = null;
        private static readonly object lockObject = new object();

        public string FilePathArticlesPurchased = ConfigurationManager.AppSettings["pathDB"] + "articles_achetes.json";

        public FileWriter FileWriter = FileWriter.Instance;
        public JsonToolkit JsonTool = new JsonToolkit();
        public DisplayConsole DC = new DisplayConsole();

        public List<PurchasedArticle> PurchasedArticlesList = new List<PurchasedArticle>();
        public List<PurchasedArticle> Basket = new List<PurchasedArticle>();
        public ServiceArticle ArticleService = ServiceArticle.Instance;

        public static ServicePurchasedArticle Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ServicePurchasedArticle();
                    }
                    return instance;
                }
            }
        }

        private ServicePurchasedArticle() { }

        public bool LoadArticlesPurchasedList()
        {
            PurchasedArticlesList = JsonTool.DeserializeArticlesPurchased(FilePathArticlesPurchased);
            if (PurchasedArticlesList == null)
            {
                PurchasedArticlesList = new List<PurchasedArticle>();
                return false;
            }
            return true;
        }

        public bool SaveArticlesPurchasedList()
        {
            return FileWriter.WriteToFile(FilePathArticlesPurchased, JsonTool.SerializeArticlesPurchased(PurchasedArticlesList));
        }

        public bool AddArticleOnBasket(Buyer Buyer, int IndexArticle)
        {
            int Quantity = DC.inputQuantity();
            if (ArticleExistOnBasket(ArticleService.ArticleList.GetByIndex(IndexArticle).Id) != null)
            {
                ArticleExistOnBasket(ArticleService.ArticleList.GetByIndex(IndexArticle).Id).Quantity += Quantity;
                return false;
            }
            else
            {
                PurchasedArticle Articles = new PurchasedArticle();
                Articles.IdBuyer = Buyer.Id;
                Articles.IdChocolate = ArticleService.ArticleList.GetByIndex(IndexArticle).Id;
                Articles.Quantity = Quantity;
                Articles.PurchasedDate = DateTime.Today;
                Basket.Add(Articles);
                return true;
            }
        }

        public PurchasedArticle ArticleExistOnBasket(Guid IdChoco)
        {
            return Basket.Find(u => u.IdChocolate == IdChoco)!;
        }

        public string validBasket(Buyer BuyerConnected)
        {
            PurchasedArticlesList = PurchasedArticlesList.Concat(Basket).ToList();
            Basket = new List<PurchasedArticle>();
            return FactureBuyer(BuyerConnected);
        }

        public float PriceArticlesPurchasedList(List<PurchasedArticle> ArticlesPurchased)
        {
            float TotalPrice = 0;
            foreach(PurchasedArticle Articles in ArticlesPurchased)
            {
                var t = ArticleService.ArticleList.GetById(Articles.IdChocolate);
                TotalPrice += Articles.Quantity * ArticleService.ArticleList.GetById(Articles.IdChocolate).Price;
            }
            return TotalPrice;
        }

        public string FactureBuyer(Buyer Buyer)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DC.FactureBuyerPart(Buyer));
            sb.Append($"{"Référence".PadRight(20)}{"Quantité".PadRight(20)}Prix\n");
            foreach (PurchasedArticle Article in Basket)
            {
                Article Art = ArticleService.ArticleList.GetById(Article.IdChocolate)!;
                if ( Art != null )
                {
                    sb.Append($"{Art.Reference.PadRight(20)}{Article.Quantity.ToString().PadRight(20)}{Art.Price}\n");
                }
            }

            sb.Append($"{"Montant Total :".PadRight(20)}{PriceArticlesPurchasedList(Basket)}\n");
            return sb.ToString();
        }


        public string FactureTotal()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{"Référence".PadRight(20)}{"Quantité".PadRight(20)}{"Prix".PadRight(20)}Date d'achat\n");
            foreach (PurchasedArticle Article in PurchasedArticlesList)
            {
                Article Art = ArticleService.ArticleList.GetById(Article.IdChocolate)!;
                if (Art != null)
                {
                    sb.Append($"{Art.Reference.PadRight(20)}{Article.Quantity.ToString().PadRight(20)}{(Art.Price.ToString()+"€").PadRight(20)}{Article.PurchasedDate.ToShortDateString()}\n");
                }
            }
            sb.Append($"{"Montant Total :".PadRight(20)}{PriceArticlesPurchasedList(PurchasedArticlesList)}€\n");
            return sb.ToString();
        }

        public string FactureByBuyer(Buyer Buyer)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{"Référence".PadRight(20)}{"Quantité".PadRight(20)}{"Prix".PadRight(20)}Date d'achat\n");
            List<PurchasedArticle> LTmp = PurchasedArticlesList.FindAll(u => u.IdBuyer == Buyer.Id);
            foreach (PurchasedArticle Article in PurchasedArticlesList)
            {
                Article Art = ArticleService.ArticleList.GetById(Article.IdChocolate)!;
                if (Art != null)
                {
                    sb.Append($"{Art.Reference.PadRight(20)}{Article.Quantity.ToString().PadRight(20)}{(Art.Price.ToString() + "€").PadRight(20)}{Article.PurchasedDate.ToShortDateString()}\n");
                }
            }
            sb.Append($"{"Montant Total :".PadRight(20)}{PriceArticlesPurchasedList(LTmp)}€\n");
            return sb.ToString();
        }

        public string FactureByDate(DateTime dateTime)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{"Référence".PadRight(20)}{"Quantité".PadRight(20)}{"Prix".PadRight(20)}Date d'achat\n");
            List<PurchasedArticle> LTmp = PurchasedArticlesList.FindAll(u => u.PurchasedDate.ToShortDateString() == dateTime.ToShortDateString());
            foreach (PurchasedArticle Article in PurchasedArticlesList)
            {
                Article Art = ArticleService.ArticleList.GetById(Article.IdChocolate)!;
                if (Art != null)
                {
                    sb.Append($"{Art.Reference.PadRight(20)}{Article.Quantity.ToString().PadRight(20)}{(Art.Price.ToString() + "€").PadRight(20)}{Article.PurchasedDate.ToShortDateString()}\n");
                }
            }

            sb.Append($"{"Montant Total :".PadRight(20)}{PriceArticlesPurchasedList(LTmp)}€\n");
            return sb.ToString();
        }
    }