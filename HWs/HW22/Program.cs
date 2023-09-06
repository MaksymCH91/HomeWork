using System.Globalization;
using System.Text.RegularExpressions;

namespace HW22
{
    class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }

    }

    class LogAnalyzer
    {
        public string LogPath { get; set; }
        public string LogSeparator { get; set; }
        public string LogTimeFormat { get; set; }

        public List<LogEntry> ParseLog()
        {
            List<LogEntry> logEntries = new List<LogEntry>();

            try
            {
                using (StreamReader reader = new StreamReader(LogPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                       
                        LogEntry logEntry = ParseLogLine(line);
                        if (logEntry != null)
                        {
                            logEntries.Add(logEntry);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading or parsing the log file: {ex.Message}");
            }

            return logEntries;
        }

        private LogEntry ParseLogLine(string logLine)
        {
            string[] parts = logLine.Split(LogSeparator);

            if (parts.Length >= 4)
            {
                string timestampStr = $"{parts[0]} {parts[1]}";
                if (DateTime.TryParseExact(timestampStr, LogTimeFormat, null, System.Globalization.DateTimeStyles.None, out DateTime timestamp))
                {
                    string message = string.Join(" ", parts[2..]);

                    return new LogEntry
                    {
                        Timestamp = timestamp,
                        Message = message
                    };
                }
            }

            // If parsing fails, return null
            return null;
        }

        
    }

    class Program
    {
        static void Main()
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer
            {
                
                LogPath = @"D:\test\Log.txt",
                LogSeparator = " ",
                LogTimeFormat = "dd.MM.yyyy HH:mm:ss"
            };
            // write log using logEntries list
            List<LogEntry> logEntries = logAnalyzer.ParseLog();
            foreach (var entry in logEntries)
            {
                Console.WriteLine($"{entry.Timestamp} {entry.Message}");
            }

            // Perform log analysis using logEntries list
            Dictionary<string, int> errorCountByType = new Dictionary<string, int>();

            foreach (var entry in logEntries)
            {
                if (errorCountByType.ContainsKey(entry.Message))
                {
                    errorCountByType[entry.Message]++;
                }
                else
                {
                    errorCountByType[entry.Message] = 1;
                }
            }

            // Display error types and their quantities
            Console.WriteLine("Error Type\tQuantity");
            foreach (var kvp in errorCountByType)
            {
                Console.WriteLine($"{kvp.Key}\t{kvp.Value}");
            }

            

        }
    }
}