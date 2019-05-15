using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger : ILogger
    {
        private const string path = "Logs/LogFile_{0}.txt";
        private readonly string log = "{0} | {1} | {2}";
        private static object locker = new object();

        public enum TypeLog
        {
            Eror,
            Info,
            Warring
        }

        public Logger()
        {

        }

        public async void Log(TypeLog typeLog, string message)
        {
            using (StreamWriter sw = new StreamWriter(string.Format(path, DateTime.Now.ToShortDateString()), true, Encoding.Unicode))
            {
                await sw.WriteLineAsync(string.Format(log, DateTime.Now.ToString("hh:mm:ss:ff"), typeLog, message));
            }
        }
    }
}
