public class Bowl 
{ 
    public void GetBowl()
    {
    }

    public void AddVegetable(Vegetable vegetable)
    {
    }
}

public class Carrot : Vegetable 
{
}

public class Potato : Vegetable
{
}

public class Vegetable 
{
    public void Get()
    {
    }

    public void Peel()
    {
    }

    public void Cut()
    {
    }
}

public class Chef
{
    public void Cook()
    {
        Bowl bowl = new Bowl();
        Vegetable carrot = new Carrot();
        Vegetable potato = new Potato();

        potato.Get();
        carrot.Get();
        potato.Peel();
        carrot.Peel();        
        
        bowl.GetBowl();
        potato.Cut();
        carrot.Cut();

        bowl.AddVegetable(carrot);
        bowl.AddVegetable(potato);
    }
}
