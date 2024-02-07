namespace Test.Services;

public interface ITestService<T>
{
    public IEnumerable<T> GetData();
}
