using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MaterialLogger
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public static void Log()
        {
            _logger.Error("Input was over 1000 or negative");
        }

        public static void Log(Exception e, string message)
        {
            _logger.Error("{0}, Exception: {1}", message, e );
        }

        public static void Log(string message)
        {
            _logger.Error("{0}, ", message);
        }
    }
}
