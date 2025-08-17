using System;

namespace AdventOfCode.Helpers
{

    public enum LogLevel
    {
        Silent,
        Information,
        Warning,
        Debug,
        All
    };


    public static class Logger
    {
        private static LogLevel _logLevel = LogLevel.Information;
        public static LogLevel LogLevel
        {
            get { return _logLevel; }
            set { _logLevel = value; }
        }
        

        public static void Log(string messages, LogLevel logLevel = LogLevel.Information)
        {
            string[] arrStrings = new string[1];
            arrStrings[0] = messages;
            Log(arrStrings, logLevel);
        }
        public static void Log(string[] messages, LogLevel logLevel = LogLevel.Information)
        {
            if (logLevel <= _logLevel)
            {
                var dateString = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}: ";
                Console.WriteLine($"{dateString}{string.Join(',', messages)}");
            }
        }
    }
}
