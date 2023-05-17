public interface ICatalog<T>
{
    void AddItem(T item);
    T GetItem(string description);
}
