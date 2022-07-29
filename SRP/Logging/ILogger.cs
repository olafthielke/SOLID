using System;
using System.Threading.Tasks;

namespace SOLID.SRP.Logging
{
    public interface ILogger
    {
        Task LogError(Exception exception);
        Task LogError(string message, Exception exception);
        Task LogWarning(string message);
        Task LogInfo(string message);
        Task LogDebug(string message, string data = null);
    }
}