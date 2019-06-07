using System;
using System.IO;
using System.Text;

namespace Logger
{
    public class Logger : ILogger
    {
        private const string _path = "Logs/LogFile_{0}.txt";
        private readonly string _log = "{0} | {1} | {2}";

        public enum TypeLog
        {
            Error,
            Info,
            Warring
        }

        public Logger()
        {

        }

        public async void Log(TypeLog typeLog, string message)
        {
            using (StreamWriter sw = new StreamWriter(string.Format(_path, DateTime.Now.ToShortDateString()), true, Encoding.Unicode))
            {
                await sw.WriteLineAsync(string.Format(_log, DateTime.Now.ToString("hh:mm:ss:ff"), typeLog, message));
            }
        }
    }
}
