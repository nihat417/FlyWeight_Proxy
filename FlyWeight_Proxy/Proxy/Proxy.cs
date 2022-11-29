
namespace FlyWeight_Proxy.Proxy;

public interface IImage
{
    void Display();
}

public class RealImage : IImage
{
    private string Filename;
    public RealImage(string filename)
    {
        Filename = filename;
        LoadFromDisk(filename);
    }
    public void Display() => Console.WriteLine($"Displaying {Filename}");
    public void LoadFromDisk(string filename) => Console.WriteLine($"Loading {filename}");
}

public class ProxyImage : IImage
{
    private RealImage RealImage;
    private string Filename;

    public ProxyImage(string filename) => Filename = filename;
    public void Display()
    {
        if (RealImage == null)
            RealImage = new RealImage(Filename);
            RealImage.Display();
    }
}

class Program
{
    static void Main()
    {
        IImage image = new ProxyImage("image.png");
        image.Display(); 
    }
}
