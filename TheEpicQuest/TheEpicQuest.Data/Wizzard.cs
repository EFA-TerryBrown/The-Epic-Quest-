using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Wizzard : Character, ICharacterYear
{
    public Wizzard() { }
    public Wizzard(bool isEvil, bool isHalfBlood, Year year, MagicType magicalAbility,
    int healthPoints, string name, House house)
    : base(healthPoints, name, house)
    {
        IsEvil = isEvil;
        IsHalfBlood = isHalfBlood;
        Year = year;
        MagicalAbility = magicalAbility;
    }


    public bool IsEvil { get; set; } = false;
    public bool IsHalfBlood { get; set; } = false;
    public Year Year { get; set; }
    public MagicType MagicalAbility { get; set; }

    public void Attack(MagicType magicalAbility, Character character)
    {
        switch (magicalAbility)
        {
            case MagicType.Charms:
                character.HealthPoints -= 30;
                System.Console.WriteLine("You Just used a Charm!");
                System.Console.WriteLine($"The enemies health is now: {character.HealthPoints}");
                System.Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
                break;

            case MagicType.Potions:
                character.HealthPoints -= 40;
                System.Console.WriteLine("You Just used a Potion!");
                System.Console.WriteLine($"The enemies health is now: {character.HealthPoints}");
                System.Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
                break;

            case MagicType.Defence_Against_DarkArts:
                this.HealthPoints += 20;
                System.Console.WriteLine("You Just Defended aginst the Dark Arts!");
                System.Console.WriteLine($"The your health is now: {this.HealthPoints}");
                System.Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
                break;

            case MagicType.Herbology:
                this.HealthPoints += 15;
                System.Console.WriteLine("You Just used Herbology");
                System.Console.WriteLine($"The your health is now: {this.HealthPoints}");
                System.Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
                break;

            case MagicType.Transfiguration:
                this.HealthPoints += 25;

                //adding enemy health loss:
                character.HealthPoints -= 75;
                System.Console.WriteLine("You Just used Transfiguration");
                System.Console.WriteLine($"The your health is now: {this.HealthPoints}");
                 System.Console.WriteLine($"The enemies health is now: {character.HealthPoints}");
                System.Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
                break;

            case MagicType.Magical_Creatures:
                character.HealthPoints -= 300;
                System.Console.WriteLine("You Just Summoned a Magical Creature!");
                System.Console.WriteLine($"The enemies health is now: {character.HealthPoints}");
                System.Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
                break;

            case MagicType.Astronomy:
                System.Console.WriteLine("You Just used Astronomy!");
                System.Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
                break;

            case MagicType.Quidditch:
                System.Console.WriteLine("You Just activated Quidditch (broomstick)!");
                System.Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
                break;

            default:
                System.Console.WriteLine("Invalid Selection!");
                System.Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
                break;
        }
    }
}