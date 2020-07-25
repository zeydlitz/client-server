using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using NLog;

namespace texode
{
    public class ErrorDetails { 
        public int StatusCode { get; set; }
        public string Message { get; set; } 

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message); 
        void LogDebug(string message); 
        void LogError(string message);
    }
    public class LoggerManager : ILoggerManager
    { 
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager() { }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        } 
        public void LogWarn(string message)
        { logger.Warn(message); }
    }
   
}
