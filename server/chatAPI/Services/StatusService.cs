using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using chatAPI.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace chatAPI.Services;

public class StatusService
{
    private readonly HashSet<Guid> _onlineUsers;
    private readonly ILogger<StatusService> _logger;

    public StatusService(ILogger<StatusService> logger)
    {
        _onlineUsers = new();
        _logger = logger;
    }

    public void AddOnlineUser(Guid id)
    {
        _onlineUsers.Add(id);
        _logger.LogInformation($"Added online user {id.ToString()}");
    }

    public void RemoveOnlineUser(Guid id)
    {
        _onlineUsers.Remove(id);
        _logger.LogInformation($"Removed online user {id.ToString()}");
    }

    public bool IsUserOnline(Guid id)
    {
        var status = _onlineUsers.Contains(id);
        _logger.LogInformation($"User {id.ToString()} is {status}");
        return status;
    }

    public IEnumerable<Guid> GetOnlineUsersIDs()
    {
        return _onlineUsers.AsEnumerable();
    }
}