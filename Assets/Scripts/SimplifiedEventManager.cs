using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimplifiedEventManager : Singleton<SimplifiedEventManager>
{
    public static UnityEvent AsteroidDeath = new UnityEvent();
    public static UnityEvent<int> PlayerDeath = new UnityEvent<int>();
    public static UnityEvent GameplayRequested = new UnityEvent();
    public static UnityEvent MainMenuRequested = new UnityEvent();

}
