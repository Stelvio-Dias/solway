namespace Solway.Interfaces;

public interface IUniteOfWork
{
    Task Dispose();
    Task SaveAsync();
}