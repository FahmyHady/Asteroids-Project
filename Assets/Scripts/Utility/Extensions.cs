using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions 
{
   public static T GetRandomElement<T>(this T[] arrayOfObject)
    {
        return arrayOfObject[Random.Range(0, arrayOfObject.Length)];
    }
}
