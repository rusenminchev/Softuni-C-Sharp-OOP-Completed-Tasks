using Skeleton;

public class StartUp
{
    static void Main(string[] args)
    {
        Dragon dragon = new Dragon("Drakkaris", new ConsoleIntroducer());
        dragon.Introduce();
    }
}
