using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheEpicQuest.Data
{
    public class World
    {
        public World(List<Level> levels)
        {
            Levels= levels;
        }
        public int ID { get; set; }
        public bool IsComplete{get; private set;}
        public List<Level> Levels { get; set; }=new List<Level>();
      
        public bool WorldCompleted()
        {
            if(Levels.Count<=0)
            {
                return true;
            }
            return false;
        }
    }
}