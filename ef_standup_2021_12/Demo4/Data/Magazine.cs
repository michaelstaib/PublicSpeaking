namespace Demo.Data;

public class Magazine : Publication
{
    public string Schedule { get; set; }
}

[ExtendObjectType(typeof(Magazine))]
public class MagazineInfo
{
    public string Info() => "This is an info"; 
}