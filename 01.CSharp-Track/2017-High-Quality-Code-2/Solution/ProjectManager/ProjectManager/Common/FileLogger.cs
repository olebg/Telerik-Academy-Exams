﻿using log4net;
using ProjectManager.Common.Contracts;

namespace ProjectManager.Common
{
    public class FileLogger : ILogger
    {
        private static ILog log;

        static FileLogger()
        {
            log = LogManager.GetLogger(typeof(FileLogger));
        }

        public void Info(object msg)
        {
            log.Info(msg);
        }

        public void Error(object msg)
        {
            log.Error(msg);
        }

        public void Fatal(object msg)
        {
            log.Fatal(msg);
        }
    }
}