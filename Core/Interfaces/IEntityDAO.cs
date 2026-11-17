namespace Core.Interfaces
{
    public interface IEntityDAO<T> where T : I_ID
    {
        T Add(T obj);

        T Update(T obj);

        T Remove(int id);

        T GetById(int id);

        List<T> GetAll();
    }
}
