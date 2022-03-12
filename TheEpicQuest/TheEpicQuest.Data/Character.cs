using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public abstract class Character
{
    public Character() { House = new House(); }

    public Character(int healthPoints, string name, House house)
    {
        HealthPoints = healthPoints;
        Name = name;
        House = house;
    }

    public Character(int healthPoints, string name, House house, int lives)
    {
        HealthPoints = healthPoints;
        Name = name;
        House = house;
        Lives = lives;
    }

    //private backing field
    private int _healthPoints { get; set; } = 100;

    public int HealthPoints
    {
        get
        {
            if (_healthPoints <= 0)
            {
                _healthPoints = 0;
                System.Console.WriteLine($"{Name} Just DIED!!!");
            }
            return _healthPoints;

        }
        set
        {

            _healthPoints = value;
        }
    }
    public int ID { get; set; }
    public string Name { get; set; }
    public House House { get; set; }
    public int Lives { get; set; } = 3;
}
