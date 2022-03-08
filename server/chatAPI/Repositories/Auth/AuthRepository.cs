using AutoMapper;
using chatAPI.Data;
using chatAPI.Models;
using chatAPI.Services;

namespace chatAPI.Repositories;

public class AuthRepository : IAuthRepository
{
    private bool disposedValue;
    private readonly ApplicationDbContext _appDb;
    private readonly UsersRepository _usersRepository;
    private readonly JwtService _jwt;
    private readonly CryptoService _crypto;
    private readonly IMapper _mapper;

    public AuthRepository(ApplicationDbContext appDb, JwtService jwt, CryptoService crypto, UsersRepository usersRepository, IMapper mapper)
    {
        _appDb = appDb;
        _jwt = jwt;
        _crypto = crypto;
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public IEnumerable<DTOs.User> GetAll()
    {
        return _usersRepository.GetAll();
    }

    public DTOs.User GetUserById(Guid id)
    {
        return _usersRepository.GetUserById(id);
    }

    public DTOs.UserLoginResponse Authenticate(string username, string password)
    {
        var user = _appDb.Users.FirstOrDefault(u => u.Username == username);
        if (user is null || _crypto.Verify(user.Password, password))
            return new()
            {
                Username = username,
                JWTToken = null,
                OperationResult = DTOs.UserLoginOperationResult.failure
            };

        return new()
        {
            Username = username,
            JWTToken = _jwt.GenerateToken(_mapper.Map<DTOs.User>(user)),
            OperationResult = DTOs.UserLoginOperationResult.success
        };
    }

    public DTOs.User ChangePassword(Guid id, string oldPassword, string newPassword)
    {
        // I think this is beyond scope 😅
        throw new NotImplementedException();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _appDb.Dispose();
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