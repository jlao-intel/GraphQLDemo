using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace GraphQL.Utilities
{
    public class NetLogger : ILogger
    {
        //singleton -- one instance with each run

        private static NetLogger instance;
        private static Logger logger;

        private NetLogger()
        {

        }

        public static NetLogger GetInstance()
        {
            if (instance == null)
                instance = new NetLogger();
            return instance;
        }

        private Logger GetLogger(string myLogger)
        {
            if (NetLogger.logger == null)
                NetLogger.logger = LogManager.GetLogger(myLogger);
            return NetLogger.logger;
        }

        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("AppRules").Debug(message);
            else
                GetLogger("AppRules").Debug(message, arg);

        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("AppRules").Error(message);
            else
                GetLogger("AppRules").Error(message, arg);
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("AppRules").Info(message);
            else
                GetLogger("AppRules").Info(message, arg);
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("AppRules").Warn(message);
            else
                GetLogger("AppRules").Warn(message, arg);
        }
    }
}
