using chatAPI.Data;
using chatAPI.Models;

namespace chatAPI.Repositories;

public class DbAuthRepository : IAuthRepository
{
    private bool disposedValue;

    private readonly ApplicationDbContext _appDb;
    private readonly AuthDbContext _authDb;

    public DbAuthRepository(ApplicationDbContext appDb, AuthDbContext authDb)
    {
        _appDb = appDb;
        _authDb = authDb;
    }

    public IEnumerable<DTOs.User> GetAll()
    {
        throw new NotImplementedException();
    }

    public DTOs.User GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }

    public DTOs.User GetUserByAccountId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Account CreateAccount(DTOs.User user)
    {
        throw new NotImplementedException();
    }

    public Account UpdateAccount(Guid id, DTOs.User user)
    {
        throw new NotImplementedException();
    }

    public Account DeleteAccount(Guid id)
    {
        throw new NotImplementedException();
    }

    public Account Authenticate(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Account ChangePassword(Guid accountId, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _appDb.Dispose();
                _authDb.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}