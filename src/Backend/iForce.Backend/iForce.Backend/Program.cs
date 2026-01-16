using System.Net;
using iForce.Backend.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
var localhostCorsPolicy = "AllowLocalhost";
builder.Services.AddCors(o => o.AddPolicy(name: localhostCorsPolicy,
    policy => policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(localhostCorsPolicy);

app.MapPost("/api/auth/login",
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(IResult))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(IResult))]
        (AuthRequest request) =>
        {
            var hardcodedUsername = "testUser";
            var hardcodedPassword = "testPassword";
            var hardcodedToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTc2ODYwMzc5OH0.7u2OElbve3NgEpZLlW45KgtSkJOT-XQwYGVbqsuOA48";
            if (request.Username == hardcodedUsername && request.Password == hardcodedPassword)
            {
                return Results.Ok(hardcodedToken);
            }

            return Results.Unauthorized();
        })
    .WithName("login")
    .WithOpenApi()
    .Produces<IResult>()
    .Produces<IResult>((int)HttpStatusCode.Unauthorized);

app.Run();
