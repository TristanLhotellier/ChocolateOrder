namespace ChocoProject.Core;
using Logs;
using System.Configuration;
using FileInteraction;
using ListManager;
using ChocoProject.Core;
using Models;

public class ServiceAdmin : InterfaceServiceAdmin
{
    public string FilePathAdmin = ConfigurationManager.AppSettings["path"] + "admin.json";

        public FileWriter FileWriter = FileWriter.Instance;
        public JsonToolkit JsonTool = new JsonToolkit();
        public DisplayConsole DC = new DisplayConsole();
        public LogWriter Logger = new LogWriter();

        public Administrator AdminConnected;
        public BaseModelList<Administrator> AdminList = new BaseModelList<Administrator>();
        public ServiceArticle ArticleService = ServiceArticle.Instance;
        public ServicePurchasedArticle PurchasedArticleService = ServicePurchasedArticle.Instance;

        public ServiceAdmin()
        {
            Logger.WriteLog((LoadAdminList() ? "Réussi" : "Echec") + " : Chargement de la liste des administrateurs depuis la DB",false);
        }

        public bool LoadAdminList()
        {
            return AdminList.setlList(JsonTool.DeserializeAdministrator(FilePathAdmin));
        }

        public bool SaveAdminList()
        {
            _ = FileWriter.WriteToFile(FilePathAdmin, JsonTool.SerializeAdministrator(AdminList.GetList()));
            return true;
        }

        public int AdminChoice()
        {
            string Input = ""; int Resultat;
            while (!int.TryParse(Input, out Resultat))
            {
                Console.WriteLine(DC.MenuAdmin());
                Input = Console.ReadLine()!;
            }
            return Resultat;
        }

        public bool AdminMenu()
        {
            bool IsFinish = false;
            while (!IsFinish)
            {
                switch (AdminChoice())
                {
                    case 1:
                        Logger.WriteLog((ArticleService.formArticle() ? "Création de l'article réussi" : "L'article existe déjà dans la DB"),false);
                        break;
                    case 2:
                        Console.WriteLine(PurchasedArticleService.FactureTotal());
                        break;
                    case 3:
                        Console.WriteLine("En construction");
                        break;
                    case 4:
                        Console.WriteLine(PurchasedArticleService.FactureByDate(DateTime.Today));
                        break;
                    case 5:
                        IsFinish = true;
                        break;
                }
            }
            return true;
        }

        public bool formAdmin()
        {
            AdminConnected = new Administrator();
            AdminConnected.Login = DC.inputLoginAdmin();
            AdminConnected.Password = DC.inputPasswordAdmin();
            if (AdminFindByPasswordAndLogin(AdminConnected.Password, AdminConnected.Login) != null)
            {
                AdminConnected = AdminFindByPasswordAndLogin(AdminConnected.Password, AdminConnected.Login);
                return true;
            }
            else
            {
                AdminList.Add(AdminConnected);
                return false;
            }
        }

        public Administrator AdminFindByPasswordAndLogin(string Password, string Login)
        {
            return AdminList.GetList().Find(u => u.Password == Password && u.Login == Login)!;
        }
    
}