using System;

namespace Assignment.Framework.Core
{
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log trace message. 
        /// Very detailed logs, which may include high-volume information such as protocol payloads. 
        /// This log level is typically only enabled during development and enforced programmatically 
        /// When application/component log level is set to 'Trace' lowest, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        void Trace(Func<string> logMessageProvider);

        /// <summary>
        /// Log debug message. 
        /// Debugging information, less detailed than trace, typically not enabled in production environment.
        /// When application/component log level is set to 'Debug' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        void Debug(Func<string> logMessageProvider);

        /// <summary>
        /// Log information message. 
        /// Information messages, which are normally enabled in production environment when required.
        /// When application/component log level is set to 'Info' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        void Info(Func<string> logMessageProvider);

        /// <summary>
        /// Log warning message. 
        /// Warning messages, typically for non-critical issues, which can be recovered or which are temporary failures
        /// When application/component log level is set to 'Warning' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        void Warning(Func<string> logMessageProvider);

        /// <summary>
        /// Log error message. 
        /// Most of the time these are Exceptions, and should use Error(Exception) or Error(Messsage, Exception).
        /// When application/component log level is set to 'Error' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        void Error(Func<string> logMessageProvider);

        /// <summary>
        /// Log exception. 
        /// When application/component log level is set to 'Error' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        /// <param name="ex">Exception</param>
        void Error(Func<string> logMessageProvider, Exception ex);

        /// <summary>
        /// Log exception. 
        /// When application/component log level is set to 'Error' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        /// <param name="ex">Exception</param>
        void Error(Exception ex);

        /// <summary>
        /// Log fatal error message. 
        /// Very serious errors. These will be logged when logging is enabled at any level.
        /// When application/component log level is set to 'Fatal' or lower, these messages will get logged
        /// </summary>
        /// <param name="logMessageProvider">Delegate providing message to log</param>
        void Fatal(Func<string> logMessageProvider);

        /// <summary>
        /// Sends the log mail.
        /// </summary>
        /// <param name="receipients">The receipients.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="content">The content.</param>
        /// <param name="ex">The ex.</param>

    }
}
