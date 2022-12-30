public interface IMovieService{

    //here i only want to work with my internal modals, hence why im using Movie instead of CreateMovieRequest
    void CreateMovie(Movie movie);
    void DeleteMovie(Guid id);
    List<Movie> GetAll();
    Movie GetMovie(Guid id);
    void UpsertMovie(Movie movie);
}