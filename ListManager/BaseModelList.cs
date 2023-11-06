using Models;
namespace ListManager;

/// <summary>
/// Manages a list of <see cref="BaseModel" objects.
/// </summary>
/// <typeparam name="T">The type of <see cref="BaseModel"/> object to manage.</typeparam>
public class BaseModelList<T> where T : BaseModel
{
    
    private List<T> list;

    public BaseModelList()
    {  
        list = new List<T>();
    }

    public bool setlList(List<T> list)
    {
        if(list != null)
        {
            this.list = list;
        }
        else
        {
            this.list = new List<T>();
        }
        return true;
    }

    public void Add(T buyer)
    {
        list.Add(buyer);
    }

    public void Remove(T buyer)
    {
        list.Remove(buyer);
    }

    public List<T> GetList()
    {
        return list;
    }

    public T GetById(Guid id)
    {
        return list.Find(u => u.Id == id)!;
    }

    public T GetByIndex(int index) 
    {
        return list[index];
    }
}