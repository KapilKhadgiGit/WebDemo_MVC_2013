using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using System.IO;

namespace WebMVCDemo.Web.Framework
{
    /// <summary>
    /// This class is used to log Exception
    /// </summary>
    public static class KLogger
    {
        #region Constants

        private const string DateFormat = "MMM-dd-yyyy";
        private const string FileFormat = ".txt";
        private const string LineBreaker = "__________________________";
        private static ILog m_log;

        #endregion Constants

        #region Variable

        private static string logFilePath = String.Empty;

        #endregion Variable

        #region Enumerations

        public enum LogMessageType
        {
            Debug,
            Info,
            Warn,
            Error,
            Fatal
        }

        #endregion Enumerations

        #region Static Methods

        public static void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void Write(string message, LogMessageType messageType)
        {
            DoLog(message, messageType, null, Type.GetType("System.Object"));
        }

        public static void Write(string message, LogMessageType messageType, Type type)
        {
            DoLog(message, messageType, null, type);
        }

        public static void Write(string message, LogMessageType messageType, Exception ex)
        {
            DoLog(message, messageType, ex, Type.GetType("System.Object"));
        }

        public static void Write(string message, LogMessageType messageType, Exception ex, Type type)
        {
            DoLog(message, messageType, ex, type);
        }

        public static void Assert(bool condition, string message)
        {
            Assert(condition, message, Type.GetType("System.Object"));
        }

        public static void Assert(bool condition, string message, Type type)
        {
            if (condition == false)
                Write(message, LogMessageType.Info);
        }

        private static void DoLog(string message, LogMessageType messageType, Exception ex, Type type)
        {
            m_log = LogManager.GetLogger(type);

            switch (messageType)
            {
                case LogMessageType.Debug:
                    KLogger.m_log.Debug(message, ex);
                    break;

                case LogMessageType.Info:
                    KLogger.m_log.Info(message, ex);
                    break;

                case LogMessageType.Warn:
                    KLogger.m_log.Warn(message, ex);
                    break;

                case LogMessageType.Error:
                    KLogger.m_log.Error(message, ex);
                    break;

                case LogMessageType.Fatal:
                    KLogger.m_log.Fatal(message, ex);
                    break;
            }
        }

        /// <summary>
        /// This log allows log message along with the entity data. This will be usedful in case of transactions. This will log messae along with the data.
        /// </summary>
        /// <param name="operation">operation</param>
        /// <param name="logMessage">log Message</param>
        /// <param name="messageType">Log MessageType</param>
        public static void WriteLog(string operation, string logMessage, LogMessageType messageType)
        {
            try
            {
                logFilePath = CheckIfLogPathExist();

                using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(logFilePath)))
                {
                    w.WriteLine("\r\nLog Entry : Type=" + messageType);
                    w.WriteLine("\r\nTimeStamp : {0}", DateTime.Now.ToString());
                    string err = "\r\nOperation: " + operation +
                                  ".\r\nLog Message:" + logMessage;
                    w.WriteLine(err);

                    w.WriteLine(LineBreaker);
                    w.Flush();
                    w.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// This will check for Log Path File. If not exists than it will create Path
        /// </summary>
        /// <returns>path of Log File</returns>
        private static string CheckIfLogPathExist()
        {
            try
            {
                string path = "Logs/" + DateTime.Today.ToString(DateFormat) + FileFormat;

                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("Logs")))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("Logs"));
                }

                if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
                }
                return path;
            }
            catch
            {
                throw;
            }
        }

        #endregion Static Methods

        public static void WriteLogForDebugMode(string p)
        {
            throw new NotImplementedException();
        }
    }
}