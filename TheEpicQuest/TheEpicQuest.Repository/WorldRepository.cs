using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEpicQuest.Data;

public class WorldRepository
{
    private readonly LevelRepository _lRepo;
    public WorldRepository(LevelRepository lRepo)
    {
        _lRepo = lRepo;
    }

    //Fake Db
    private readonly List<World> _worldRepository = new List<World>();

    int _counter;
    //use CRUD

    //C
    public bool AddNewWorld(World world)
    {
        if (world != null)
        {
            _counter++;
            world.ID = _counter;
            _worldRepository.Add(world);
            return true;
        }
        else
        {
            return false;
        }
    }

    //R
    public List<World> GetAllWorlds()
    {
        return _worldRepository;
    }

    //R Helper method
    public World GetWorldByID(int id)
    {
        foreach (var world in _worldRepository)
        {
            if (world.ID == id)
            {
                return world;
            }
        }
        return null;
    }


    //set world to iscomplete
    public bool WorldCompleted(int id)
    {
        //I need a world
        var world = GetWorldByID(id);
        if (world != null)
        {
            if (_lRepo.GetAllLevels().Count <= 0)
            {
                return world.WorldCompleted();
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //Add Delete method for the world
    public bool DeleteWorld(int id)
    {
        foreach (var world in _worldRepository)
        {
            if (world.ID == id)
            {
                _worldRepository.Remove(world);
                return true;
            }
        }
        return false;
    }

    public bool RemoveLevel(int id)
    {
        foreach (var world in _worldRepository)
        {
            foreach (var level in world.Levels)
            {
                if (level.ID == id)
                {
                    world.Levels.Remove(level);
                    return true;
                }
            }
        }
        return false;
    }
}
