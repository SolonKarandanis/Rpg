using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Utils
{
    public class ListUtils
    {
        public static bool IsEmpty<T>(List<T> list)
        {
            if (list == null) {
                return true;
            }
    
            return !list.Any();
        }
    }
}