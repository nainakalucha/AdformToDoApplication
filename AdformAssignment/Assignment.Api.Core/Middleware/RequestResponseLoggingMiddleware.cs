using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Assignment.Api.Core.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestResponseLoggingMiddleware
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate _next;
        /// <summary>
        /// The logger
        /// </summary>
        private Framework.Core.ILogger _logger;
        /// <summary>
        /// The recyclable memory stream manager
        /// </summary>
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;


        /// <summary>
        /// Initializes a new instance of the <see cref="RequestResponseLoggingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }


        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public async Task Invoke(HttpContext context, Framework.Core.ILogger logger)
        {
            _logger = logger;
            await LogRequest(context);
            await LogResponse(context);
        }


        /// <summary>
        /// Logs the request.
        /// </summary>
        /// <param name="context">The context.</param>
        private async Task LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();
            using (var requestStream = _recyclableMemoryStreamManager.GetStream())
            {
                await context.Request.Body.CopyToAsync(requestStream);
                _logger.Info(() => $"Http Request Information:{Environment.NewLine}" +
                                   $"Schema:{context.Request.Scheme} " +
                                   $"Host: {context.Request.Host} " +
                                   $"Path: {context.Request.Path} " +
                                   $"QueryString: {context.Request.QueryString} " +
                                   $"Request Body: {ReadStreamInChunks(requestStream)}");
            }          
            context.Request.Body.Position = 0;
        }


        /// <summary>
        /// Logs the response.
        /// </summary>
        /// <param name="context">The context.</param>
        private async Task LogResponse(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            using (var responseBody = _recyclableMemoryStreamManager.GetStream())
            {
                context.Response.Body = responseBody;
                await _next(context);
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                _logger.Info(() => $"Http Response Information:{Environment.NewLine}" +
                                       $"Schema:{context.Request.Scheme} " +
                                       $"Host: {context.Request.Host} " +
                                       $"Path: {context.Request.Path} " +
                                       $"QueryString: {context.Request.QueryString} " +
                                       $"Response Body: {text}");
                await responseBody.CopyToAsync(originalBodyStream);
            }           
        }


        /// <summary>
        /// Reads the stream in chunks.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            stream.Seek(0, SeekOrigin.Begin);
            using (var textWriter = new StringWriter())
            using (var reader = new StreamReader(stream))
            {
                var readChunk = new char[readChunkBufferLength];
                int readChunkLength;
                do
                {
                    readChunkLength = reader.ReadBlock(readChunk, 0, readChunkBufferLength);
                    textWriter.Write(readChunk, 0, readChunkLength);
                } while (readChunkLength > 0);
                return textWriter.ToString();
            }
        }
    }
}
