using Microsoft.Extensions.Logging;
using System;

namespace Servisi.Servisi
{
    public class Logger:ILogger
    {
        private readonly string crt = "\n-----------------------------------------------\n";
        public Logger()
        {

        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        //Logging the log level and the message passed in to it
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.WriteLine(crt+"Log level: " + logLevel.ToString()+"\nMessage :" + state.ToString()+crt);
        }

    }
}
