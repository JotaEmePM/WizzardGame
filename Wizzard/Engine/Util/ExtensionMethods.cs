﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Wizzard.Engine.Util
{
    public static class ExtensionMethods
    {

        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }
        public static void AddIfMissing<T>(this HashSet<T> set, T newElement)
        {
            if (!set.Contains(newElement))
            {
                set.Add(newElement);
            }
        }

        public static void RemoveIfExists<T>(this HashSet<T> set, T newElement)
        {
            if (set.Contains(newElement))
            {
                set.Remove(newElement);
            }
        }

        public static void RemoveIfExists<T, V>(this Dictionary<T, V> map, T toRemove)
        {
            if (map.ContainsKey(toRemove))
            {
                map.Remove(toRemove);
            }
        }

        public static V GetOrDefault<T, V>(this Dictionary<T, V> map, T key, V defaultValue)
        {
            if (map.ContainsKey(key))
            {
                return map[key];
            }
            return defaultValue;
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        //public static bool IsMobile(this Platform platform)
        //{
        //    return platform == Platform.ANDROID || platform == Platform.IOS;
        //}

        //public static bool IsDesktop(this Platform platform)
        //{
        //    return platform == Platform.MAC_OSX || platform == Platform.WINDOWS || platform == Platform.LINUX;
        //}
    }
}
