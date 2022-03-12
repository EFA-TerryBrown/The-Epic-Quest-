using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class House
{
    //we want to be able to make a house 'on-the-fly'
    public House() { }
    public House(Character headOfHouse, string name, string color, Ghost ghost, Symbol mascott)
    {
        HeadOfHouse = headOfHouse;
        Name = name;
        Color = color;
        Ghost = ghost;
        Mascott = mascott;
    }

     public House(Character headOfHouse, string name, string color, Ghost ghost, Symbol mascott,List<Character> houseMembers)
    {
        HeadOfHouse = headOfHouse;
        Name = name;
        Color = color;
        Ghost = ghost;
        Mascott = mascott;
        HouseMembers=houseMembers;
    }


    //These are our attributes that 'define' the House
    public Character HeadOfHouse { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public Ghost Ghost { get; set; }
    public Symbol Mascott { get; set; }
    public List<Character> HouseMembers { get; set; } = new List<Character>();
}
