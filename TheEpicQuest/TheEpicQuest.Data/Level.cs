using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Level
{
    public Level(List<Wizzard> evilWizzards)
    {
        EvilWizzards = evilWizzards;
    }

    public int ID { get; set; }
    public List<Wizzard> EvilWizzards { get; set; }= new List<Wizzard>();
    public bool isComplete { get; private set; }

    public bool LevelComplete()
    {
        if (EvilWizzards.Count <= 0)
        {
            isComplete = true;
            return isComplete;
        }
        else
        {
            isComplete = false;
            return isComplete;
        }
    }


}
