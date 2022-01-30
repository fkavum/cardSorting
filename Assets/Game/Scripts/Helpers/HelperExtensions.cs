using System;
using System.Collections.Generic;

namespace CardSorting.Helpers
{
    public static class HelperExtensions
    {
        /// <summary>
        /// Source: https://stackoverflow.com/questions/108819/best-way-to-randomize-an-array-with-net
        /// </summary>
        /// <param name="rng"></param>
        /// <param name="array"></param>
        /// <typeparam name="T"></typeparam>
        public static void Shuffle<T> (this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1) 
            {
                int k = rng.Next(n--);
                (array[n], array[k]) = (array[k], array[n]);
            }
        }
        
        public static void Shuffle<T> (this Random rng, List<T> list)
        {
            int n = list.Count;
            while (n > 1) 
            {
                int k = rng.Next(n--);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }
    }

}
