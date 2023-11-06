using ListManager;
using Models;
using System.Text;
using System.Text.RegularExpressions;

namespace ChocoProject.Core;

public class DisplayConsole
{
   
        
        public string inputLastNameBuyer()
        {
            Console.WriteLine("Entrez un nom");
            return Console.ReadLine()!;
        }
        
        public string inputFirstNameBuyer()
        {
            Console.WriteLine("Entrez un prénom");
            return Console.ReadLine()!;
        }

        public string inputAdressBuyer()
        {
            Console.WriteLine("Entrez une adresse");
            return Console.ReadLine()!;
        }

        public string inputTelBuyer()
        {
            Console.WriteLine("Entrez un N° de téléphone");
            return Console.ReadLine()!;
        }

        

        public string inputLoginAdmin()
        {
            Console.WriteLine("Entrez un Identifiant");
            return Console.ReadLine()!;
        }

        public string inputPasswordAdmin()
        {
            bool MotDePasseValide = false; string Password = "";
            Console.WriteLine("Entrez un mot de passe");
            while (!MotDePasseValide)
            {
                Password = Console.ReadLine()!;
                if (!Regex.IsMatch(Password, @"[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]") && Password.Length < 6)
                {
                    Console.WriteLine("Mot de passe incorrect, essayez un autre mot de passe :");
                }
                else
                {
                    MotDePasseValide = true;
                }
            }
            return Password;
        }

        public float InputPriceArticle()
        {
            // string Input = ""; float Resultat;
            // while(float.TryParse(Input, out Resultat))
            // {
            //     Console.WriteLine("Prix de l'article");
            //     Input = Console.ReadLine()!;
            // }
            // return Resultat;
            
            Console.WriteLine("Prix de l'article");
            
            return float.Parse(Console.ReadLine()!);
        }

        public string InputReferenceArticle()
        {
            Console.WriteLine("Référence de l'article");
            return Console.ReadLine()!;
        }

        public int inputQuantity()
        {
            Console.WriteLine("Combien en voulez-vous ?");
            
            return int.Parse(Console.ReadLine()!);
        }

        public string PrintArticleList(BaseModelList<Article> ArticleList)
        {
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Liste des articles :\n");
            int index = 0;
            foreach (Article Article in ArticleList.GetList())
            {
                Sb.Append($"Index : {index}, Référence : {Article.Reference}, Prix : {Article.Price}€\n");
                index++;
            }
            return Sb.ToString();
        }

        public string MenuAdmin()
        {
            return "Vous voulez : \n1 : Ajouter un article \n" + "2 : Créer une facture \n" + "3 : Créer une facture par acheteurs \n" + "4 : Créer une facture par date d'achat \n" + "5 : Quitter \n";
        }

        
        

        public string FactureBuyerPart(Buyer Buyer)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nom client : " + Buyer.LastName + "\n");
            sb.Append("Prénom client : " + Buyer.FirstName + "\n");
            sb.Append("Téléphone client : " + Buyer.Phone + "\n");
            return sb.ToString();
        }

    
}