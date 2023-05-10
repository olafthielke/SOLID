using System;
using System.Threading.Tasks;

namespace SOLID.SRP.Logging
{
    public class NullLogger : ILogger
    {
        public async Task LogError(Exception exception)
        {
            // Do Nothing;
            await Task.CompletedTask;
        }

        public async Task LogError(string message, Exception exception)
        {
            // Do Nothing;
            await Task.CompletedTask;
        }

        public async Task LogWarning(string message)
        {
            // Do Nothing;
            await Task.CompletedTask;
        }

        public async Task LogInfo(string message)
        {
            // Do Nothing;
            await Task.CompletedTask;
        }

        public async Task LogDebug(string message, string data = null)
        {
            // Do Nothing;
            await Task.CompletedTask;
        }
    }
}