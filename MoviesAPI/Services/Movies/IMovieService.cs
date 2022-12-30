public interface IMovieService{

    //here i only want to work with my internal modals, hence why im using Movie instead of CreateMovieRequest
    void CreateMovie(Movie movie);
    List<Movie> GetAll();
    Movie GetMovie(Guid id);
}