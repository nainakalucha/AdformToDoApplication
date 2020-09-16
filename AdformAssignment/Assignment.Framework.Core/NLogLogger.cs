using NLog;
using System;

namespace Assignment.Framework.Core
{
    public enum TctpLogLevel
    {
        /// <summary>
        /// Trace log level
        /// </summary>
        Trace = 1,

        /// <summary>
        /// Debug log level
        /// </summary>
        Debug = 2,

        /// <summary>
        /// Information log level
        /// </summary>
        Info = 3,

        /// <summary>
        /// Warning log level
        /// </summary>
        Warn = 4,

        /// <summary>
        /// Error log level
        /// </summary>
        Error = 5,

        /// <summary>
        /// Fatal log level
        /// </summary>
        Fatal = 6,
    }

    /// <summary>
    /// Implments ILogger using NLog
    /// </summary>
    public class NLogLogger : ILogger
    {
        #region Fields

        /// <summary>
        /// NLog instance 
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiate logger
        /// </summary>
        public NLogLogger()
        {

        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Log trace message. 
        /// Very detailed logs, which may include high-volume information such as protocol payloads. 
        /// This log level is typically only enabled during development and enforced programmatically 
        /// When application/component log level is set to 'Trace' lowest, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        public void Trace(Func<string> logMessageProvider)
        {
            if (logMessageProvider != null)
                Log(TctpLogLevel.Trace, logMessageProvider);
        }

        /// <summary>
        /// Log debug message. 
        /// Debugging information, less detailed than trace, typically not enabled in production environment.
        /// When application/component log level is set to 'Debug' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        public void Debug(Func<string> logMessageProvider)
        {
            if (logMessageProvider != null)
                Log(TctpLogLevel.Debug, logMessageProvider);
        }

        /// <summary>
        /// Log information message. 
        /// Information messages, which are normally enabled in production environment when required.
        /// When application/component log level is set to 'Info' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        public void Info(Func<string> logMessageProvider)
        {
            if (logMessageProvider != null)
                Log(TctpLogLevel.Info, logMessageProvider);
        }

        /// <summary>
        /// Log warning message. 
        /// Warning messages, typically for non-critical issues, which can be recovered or which are temporary failures
        /// When application/component log level is set to 'Warning' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        public void Warning(Func<string> logMessageProvider)
        {
            if (logMessageProvider != null)
                Log(TctpLogLevel.Warn, logMessageProvider);
        }

        /// <summary>
        /// Log error message. 
        /// Most of the time these are Exceptions.
        /// When application/component log level is set to 'Error' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        public void Error(Func<string> logMessageProvider)
        {
            if (logMessageProvider != null)
                Log(TctpLogLevel.Error, logMessageProvider);
        }

        /// <summary>
        /// Log exception. 
        /// When application/component log level is set to 'Error' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        /// <param name="ex">Exception</param>
        public void Error(Func<string> logMessageProvider, Exception ex)
        {
            if (logMessageProvider != null)
                Log(TctpLogLevel.Error, logMessageProvider, ex);
        }

        /// <summary>
        /// Log exception. 
        /// When application/component log level is set to 'Error' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        /// <param name="ex">Exception</param>
        public void Error(Exception ex)
        {
            if (ex != null)
                Log(TctpLogLevel.Error, () => "TCTP Exception", ex);
        }

        /// <summary>
        /// Log fatal error message. 
        /// Very serious errors. These will be logged when logging is enabled at any level.
        /// When application/component log level is set to 'Fatal' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        public void Fatal(Func<string> logMessageProvider)
        {
            if (logMessageProvider != null)
                Log(TctpLogLevel.Fatal, logMessageProvider);
        }

      
        
        #endregion

        #region Private Methods

       

        private void Log(TctpLogLevel tctpLogLevel, Func<string> logMessageProvider, Exception ex = null)
        {
            try
            {
                
                    // Map to NLog log level
                    LogLevel logLevel = ConvertLogLevelToNlogLevel(tctpLogLevel);
                    LogEventInfo logEvent = new LogEventInfo(logLevel, "", logMessageProvider());

                    if (ex != null)
                    {
                        logEvent.Exception = ex;
                    }

                    logger.Log(logEvent);
                
            }
            catch (Exception exc)
            {
                // Logger should not throw an exception
            }

        }


        /// <summary>
        /// Map T
        /// </summary>
        /// <param name="tctpLogLevel"></param>
        /// <returns></returns>
        private LogLevel ConvertLogLevelToNlogLevel(TctpLogLevel tctpLogLevel)
        {
            LogLevel nLogLevel;
            switch (tctpLogLevel)
            {
                case TctpLogLevel.Debug:
                    nLogLevel = LogLevel.Debug;
                    break;
                case TctpLogLevel.Warn:
                    nLogLevel = LogLevel.Warn;
                    break;
                case TctpLogLevel.Error:
                    nLogLevel = LogLevel.Error;
                    break;
                case TctpLogLevel.Fatal:
                    nLogLevel = LogLevel.Fatal;
                    break;
                case TctpLogLevel.Trace:
                    nLogLevel = LogLevel.Trace;
                    break;
                case TctpLogLevel.Info:
                default:
                    nLogLevel = LogLevel.Info;
                    break;
            }

            return nLogLevel;
        }

        #endregion

        #endregion
    }

}
