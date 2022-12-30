using MoviesAPI.services.Movies;

var builder = WebApplication.CreateBuilder(args);
{
builder.Services.AddControllers();
builder.Services.AddSingleton<IMovieService,MovieService>();
//add singleton = just one instance of moveserivce is created and
//everytime an object is created an it requests the movieService interface, the instance created is used


//another option would be to use AddScoped, meaning within the life of a sigle request, the 
//first time someone requests this interface then create a new object is created,but from now
//until the app have finished processing the request, every time an object is created and it
//requests the movie service interface, then the instance creted is returned

//another option:AddTransiant: every time an object requests the movie service interface, create a new movie service object
}

// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();
{

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();

}
