using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Utils
{
    public class ArrayUtils
    {
        public static T[] InitialiseArray<T>(int length, T initialValue = default(T)){
            if(length < 0)
                return default(T[]);
            
            var arr = new T[length];
            for(var i = 0; i < length; i ++)
            {
                arr[i] = initialValue;
            }

            return arr;
        }
    }
}