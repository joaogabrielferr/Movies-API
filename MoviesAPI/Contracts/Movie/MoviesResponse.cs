public record MoviesResponse{
    
    public List<MovieResponse> movies;

    public void map(List<MovieResponse> all){
        movies = all;
    }

}