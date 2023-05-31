using API;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();
#region rate limiting
builder.Services.AddRateLimiter(options =>
{
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429; // 418: Teapot
        if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
        {
            await context.HttpContext.Response.WriteAsync(
            $"Too many requests. Please try again after {retryAfter.TotalMinutes} minute(s)." /*+ $"Read more about our rate limits at https://example.org/docs/ratelimiting."*/, cancellationToken: token);
        }
        else
        {
            await context.HttpContext.Response.WriteAsync(
            "Too many requests. Please try again later." /* + "Read more about our rate limits at https://example.org/docs/ratelimiting."*/, cancellationToken: token);
        }
    }; options.GlobalLimiter = PartitionedRateLimiter.CreateChained(
    PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
    RateLimitPartition.GetFixedWindowLimiter(httpContext.ResolveClientIpAddress(), partition =>
    new FixedWindowRateLimiterOptions
    {
        AutoReplenishment = true,
        PermitLimit = 600,
        Window = TimeSpan.FromMinutes(1)
    })),
    PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
    RateLimitPartition.GetFixedWindowLimiter(httpContext.ResolveClientIpAddress(), partition =>
    new FixedWindowRateLimiterOptions
    {
        AutoReplenishment = true,
        PermitLimit = 6000,
        Window = TimeSpan.FromHours(1)
    })),
    PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
   RateLimitPartition.GetFixedWindowLimiter(httpContext.ResolveClientIpAddress(), partition =>
    new FixedWindowRateLimiterOptions
    {
        AutoReplenishment = true,
        PermitLimit = 10,
        QueueLimit = 6,
        QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
        Window = TimeSpan.FromSeconds(1)
    }))
    );
});
#endregion

var app = builder.Build(); 
app.MapHealthChecks("/Health");
app.UseRateLimiter();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
