using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class WizzardRepository
{
    //make a fake database 
    private readonly List<Wizzard> _wizzardDatabase = new List<Wizzard>();
    //?Starting dbID counter
    int _counter = 0;

    //todo Use Crud 

    //todo Create
    public bool AddWizzardToGameDb(Wizzard wizzard)
    {
        if (wizzard != null)
        {
            AssignId(wizzard);
            _wizzardDatabase.Add(wizzard);
            return true;
        }
        return false;
    }
    private void AssignId(Wizzard wizzard)
    {
        _counter++;
        wizzard.ID = _counter;
    }

    //todo Read (GetAll)
    public List<Wizzard> GetAllWizzards()
    {
        return _wizzardDatabase;
    }

    //todo Read (GetByID) (Helper Method)
    public Wizzard GetWizzardByID(int id)
    {
        foreach (Wizzard wizzard in _wizzardDatabase)
        {
            if(wizzard.ID==id)
            {
                return wizzard;
            }
        }
        return null;
    }

    //todo Update (by ID)
    public bool UpdateWizzard(int ID, Wizzard newWizzardInfo)
    {
        //?Use the Helper method:
        Wizzard oldWizzardData = GetWizzardByID(ID);
        if(oldWizzardData != null)
        {
            oldWizzardData.Name= newWizzardInfo.Name;
            oldWizzardData.IsEvil=newWizzardInfo.IsEvil;
            oldWizzardData.IsHalfBlood=newWizzardInfo.IsHalfBlood;
            oldWizzardData.MagicalAbility=newWizzardInfo.MagicalAbility;
            oldWizzardData.HealthPoints=newWizzardInfo.HealthPoints;
            oldWizzardData.House=newWizzardInfo.House;
            oldWizzardData.Year=newWizzardInfo.Year;

            return true;
        }

        return false;
    }

    //todo Delete (by ID)
    public bool DeleteWizzard(int id)
    {
        // foreach (Wizzard wizzard in _wizzardDatabase)
        // {
        //     if(wizzard.ID == id)
        //     {
        //         _wizzardDatabase.Remove(wizzard);
        //         return true;
        //     }
        // }
        // return false;

        //? L.I.N.Q
        var wizzard= _wizzardDatabase.FirstOrDefault(w=>w.ID==id);
        return _wizzardDatabase.Remove(wizzard);
    }
    public void ResetCounter()
    {
        _counter=1;
        foreach (var wizzard in _wizzardDatabase)
        {
            wizzard.ID=_counter;
            _counter++;
        }
    }

    public bool DeleteWizzardByName(string name)
    {
        foreach (var wizzard in _wizzardDatabase)
        {
            if(wizzard.Name==name)
            {
                _wizzardDatabase.Remove(wizzard);
                return true;
            }
        }
        return false;
    }

  
}
