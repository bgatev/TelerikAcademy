public class Hauptklasse
{
    public enum HumanSex 
    { 
        male, 
        female 
    };

  public class Human
  {
    public HumanSex Sex { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }
  }

  public void MakeHuman(int EGN)
  {
      Human human = new Human();
      human.Age = EGN;
      if (EGN % 2 == 0)
      {
          human.Name = "Батката";
          human.Sex = HumanSex.male;
      }
      else
      {
          human.Name = "Мацето";
          human.Sex = HumanSex.female;
      }
  }
}
