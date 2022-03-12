using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class LevelRepository
    {
        //Fake Db
        private readonly List<Level> _levelRepository = new List<Level>();

        int _counter;
        //use CRUD
        
        //C
        public bool AddNewLevel(Level level)
        {
            if(level != null)
            {
                _counter++;
                level.ID=_counter;
                _levelRepository.Add(level);
                return true;
            }
            else
            {
               return false;
            }
        }

        //R
        public List<Level> GetAllLevels()
        {
            return _levelRepository;
        }

        //R Helper method
        public Level GetLevelById(int id)
        {
            foreach (var level in _levelRepository)
            {
                if(level.ID==id)
                {
                    return level;
                }
            }
            return null;
        }

        //Delete method 
        public bool RemoveLevel(int id)
        {
            foreach (var level in _levelRepository)
            {
                if(level.ID==id)
                {
                    _levelRepository.Remove(level);
                    return true;
                }
            }
            return false;
        }
    }
