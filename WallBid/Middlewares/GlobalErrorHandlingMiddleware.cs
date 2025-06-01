using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using WallBid.Infrastructure.Commons.Concrates;
using WallBid.Infrastructure.Exceptions;

namespace WallBid.Infrastructure.Middlewares
{
    public class GlobalErrorHandlingMiddleware(RequestDelegate next)
    {

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ApiResponse response;

                switch (ex)
                {
                    case NotFoundException notFoundException:
                        response = ApiResponse.Fail(notFoundException.Message, HttpStatusCode.NotFound);
                        break;
                    case BadRequestException badRequestException:
                        response = ApiResponse.Fail(badRequestException.Errors, badRequestException.Message, HttpStatusCode.BadRequest);
                        break;
                    case UnhandledException:
                    default:
                        Console.WriteLine(ex.ToString());
                        response = ApiResponse.Fail("Xəta baş verdi! Zəhmət olmasa, bir az sonra yenidən cəhd edin!", HttpStatusCode.InternalServerError);
                        break;
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)response.StatusCode;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy(),
                    },
                    NullValueHandling = NullValueHandling.Ignore,
                }));
            }
        }
    }

    public static class GlobalErrorHandlingExtension
    {
        public static IApplicationBuilder UseGlobalErrorHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalErrorHandlingMiddleware>();

            return builder;
        }
    }

}
