using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers;

[ApiController] //api controller atribute we get out of the box with asp.net, does some heavy lifting
[Route("api/movies")]
// if i write [Route("[Controller]")] then the prefix of the routes will be the name of the class without the word controller
public class MoviesController : ControllerBase{
    
    //behind the scenes, every time a request is made,
    //the framework creates a new MoviesController object
    //when it does that, it also tries to create a new IMovieService object
    //because of that, the framework doesnt know how to instanciate the interface the controller is requesting
    //This is fixed by defining in the program.cs file how to create the ImovieService interface (defining it as a sigleton, scoped, etc)

    public readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService) //independence injection vrau
    {
        _movieService = movieService;
    }

    //defining endpoints
    [HttpPost]
    public IActionResult CreateMovie(CreateMovieRequest request){
        
        //mapping request to Movie class
        //maybe it would be better to create a map function like I did for the movie response
        Movie movie = new Movie(Guid.NewGuid(),request.Name,request.Description,request.MovieGenres,request.releaseDateTime,DateTime.UtcNow);
        
        //TODO: SAVE MOVIES TO DATABASE
        _movieService.CreateMovie(movie);

        //mapping it to the movies response
        MovieResponse response = new MovieResponse();
        response.map(movie);
        Console.WriteLine(response);
        return CreatedAtAction(
            actionName: nameof(GetMovie),
            routeValues: new {id = movie.Id},
            value: response);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetMovie(Guid id){
        Movie movie = _movieService.GetMovie(id);

        MovieResponse response = new MovieResponse();
        response.map(movie);

        return Ok(response);
    }

    /////////////////////////////////////////////////////////////////

    [HttpGet("all")]
    public IActionResult GetAllMovies(){
        
        List<Movie> movies = _movieService.GetAll();
        Console.WriteLine("MOVIES:",movies);

        List<MovieResponse> response = new();
        foreach (var movie in movies)
        {  
            MovieResponse r = new MovieResponse();
            r.map(movie);
            response.Add(r);
        }

        return Ok(response);
    }

    /////////////////////////////////////////////////////////////////

    [HttpPut("{id:guid}")]
    public IActionResult UpsertMovie(Guid id, UpsertBreakfastRequest request)
    {
        Movie movie = new Movie(Guid.NewGuid(),request.Name,request.Description,request.MovieGenres,request.releaseDateTime,DateTime.UtcNow);
        
        _movieService.UpsertMovie(movie);

        //return 201 if a new movie is created
        // return NoContent(); //returning no content if the param id is already the ID of some movie in the database
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMovie(Guid id)
    {
        _movieService.DeleteMovie(id);
        return NoContent();
    }

}