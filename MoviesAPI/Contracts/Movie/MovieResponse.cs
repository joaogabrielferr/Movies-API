public record MovieResponse{

    public Guid Id {get; set;} //guid : represents an unique global identifier, a 16 byte value that is generated
    public string Name {get; set;}
    public string Description {get;set;}
    public List<string> MovieGenres {get;set;}
    public DateTime releaseDateTime {get;set;}
    public DateTime lastModified {get;set;}

    public void map(Movie movie){
        Id = movie.Id;
        Name = movie.Name;
        Description = movie.Description;
        MovieGenres = movie.MovieGenres;
        releaseDateTime = movie.ReleaseDateTime;
        lastModified = movie.LastModified;
    }


}