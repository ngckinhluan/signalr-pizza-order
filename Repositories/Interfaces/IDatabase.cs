namespace Repositories.Interfaces;

public interface IDatabase
{
    Task<ITransaction> BeginTransactionAsync();
}