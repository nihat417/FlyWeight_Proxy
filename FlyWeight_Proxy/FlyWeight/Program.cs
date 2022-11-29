using System.Collections;

class FlyweightFactory
{
    Hashtable flyweights = new Hashtable();
    public FlyweightFactory()
    {
        flyweights.Add("X", new ConcreteFlyweight());
        flyweights.Add("Y", new ConcreteFlyweight());
        flyweights.Add("Z", new ConcreteFlyweight());
    }
    public Flyweight GetFlyweight(string key)
    {
        if (!flyweights.ContainsKey(key))
            flyweights.Add(key, new ConcreteFlyweight());
        return flyweights[key] as Flyweight;
    }
}

abstract class Flyweight
{
    public abstract void Operation(int extrinsicState);
}

class ConcreteFlyweight : Flyweight
{
    int intrinsicState;
    public override void Operation(int extrinsicState)
    {
    }
}

class UnsharedConcreteFlyweight : Flyweight
{
    int allState;
    public override void Operation(int extrinsicState)
    {
        allState = extrinsicState;
    }
}

class Client
{
    void Main()
    {
        int extrinsicstate = 22;

        FlyweightFactory f = new FlyweightFactory();

        Flyweight fx = f.GetFlyweight("X");
        fx.Operation(--extrinsicstate);

        Flyweight fy = f.GetFlyweight("Y");
        fy.Operation(--extrinsicstate);

        Flyweight fd = f.GetFlyweight("D");
        fd.Operation(--extrinsicstate);

        UnsharedConcreteFlyweight uf = new UnsharedConcreteFlyweight();

        uf.Operation(--extrinsicstate);
    }
}