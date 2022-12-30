public class CreateMovieRequest{

    public string Name {get; set;}
    public string Description {get;set;}
    public List<string> MovieGenres {get;set;}
    public DateTime releaseDateTime {get;set;}
}