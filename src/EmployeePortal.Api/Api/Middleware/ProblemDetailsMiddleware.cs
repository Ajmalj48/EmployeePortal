namespace EmployeePortal.Api.Api.Middleware
{
    public class ProblemDetailsMiddleware(RequestDelegate next,ILogger<ProblemDetailsMiddleware> logger)
    {
        public async Task Invoke(HttpContext ctx)
        {
            try { await next(ctx); }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled error");
                ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await ctx.Response.WriteAsJsonAsync(new
                {
                    title = "Server error",
                    detail = ex.Message
                });
            }
        }
    }

}
