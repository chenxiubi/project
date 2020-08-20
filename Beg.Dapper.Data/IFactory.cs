namespace Beg.Dapper.Data
{
    public interface IFactory<T>
    {
        T GetInstance();
    }
}
