public class Movie{

    //not using setters to ensure that enyone holding a Movie object cannot simply change values
    //in the object, because i want to make sure this is always built with correct values

    public Guid Id {get; }
    public string Name {get; }
    public string Description {get;}
    public List<string> MovieGenres {get;}
    public DateTime ReleaseDateTime {get;}
    public DateTime LastModified {get;set;}


    public Movie(Guid id, string name, string desc, List<string>moviegenres,DateTime release,DateTime lastMod)
    {
        //here i can enforce whatever logic i want
        //for exemple: Name cant have less than 3 chars, movieGenres need to have a length of at least one, etc
        Id = id;
        Name = name;
        Description = desc;
        MovieGenres = moviegenres;
        ReleaseDateTime = release;
        LastModified = lastMod;
    }

}