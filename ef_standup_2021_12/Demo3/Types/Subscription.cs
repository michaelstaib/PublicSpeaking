namespace Demo;

public class Subscription
{
    [Subscribe]
    [Topic]
    public Book OnBookReleased([EventMessage] Book book) 
        => book;
}
