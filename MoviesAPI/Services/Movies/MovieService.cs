namespace MoviesAPI.services.Movies;

public class MovieService : IMovieService{
    
    private static readonly Dictionary<Guid,Movie> movies = new();
    public void CreateMovie(Movie movie)
    {
        //TODO: store in a database
        movies.Add(movie.Id,movie);
    }

    public Movie GetMovie(Guid id)
    {
        return movies[id];   
    }

    public List<Movie> GetAll(){
        
        List<Movie> all = new();
        foreach (KeyValuePair<Guid,Movie> movie in movies)
        {
            all.Add(movie.Value);
        }

        return all;
    }
}