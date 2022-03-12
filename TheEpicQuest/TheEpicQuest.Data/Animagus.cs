using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Animagus : Wizzard, IAnimal
{
    public Animagus(){}

    public Animagus(string animalName,bool isEvil, bool isHalfBlood, Year year, MagicType magicalAbility,
    int healthPoints,string name, House house) 
    : base(isEvil,isHalfBlood,year,magicalAbility,healthPoints,name,house)
    {
        AnimalName = animalName;
    }
    
    public string AnimalName { get; set; }
}
