using Ganss.Xss;
using System.Text;

namespace WallBid.AdminPanel.Middlewares
{
    public class XssSanitizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HtmlSanitizer _sanitizer;

        public XssSanitizationMiddleware(RequestDelegate next)
        {
            _next = next;
            _sanitizer = new HtmlSanitizer();
            _sanitizer.AllowedTags.Remove("script");
            _sanitizer.AllowedAttributes.Clear();
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.ContentType != null && context.Request.ContentType.Contains("application/json"))
            {
                context.Request.EnableBuffering();

                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
                {
                    var body = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;

                    var sanitizedBody = _sanitizer.Sanitize(body);

                    var sanitizedBytes = Encoding.UTF8.GetBytes(sanitizedBody);
                    context.Request.Body = new MemoryStream(sanitizedBytes);
                    context.Request.Body.Position = 0;
                }
            }

            await _next(context);
        }
    }
}
