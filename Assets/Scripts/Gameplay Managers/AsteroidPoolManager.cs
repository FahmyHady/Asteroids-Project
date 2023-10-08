using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> availablePool = new List<T>();
    private T prefab;
    private Transform parent;
    public ObjectPool(T prefab, Transform parent, int initialPoolSize)
    {
        this.prefab = prefab;
        this.parent = parent;
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateObject();
        }
    }
    T CreateObject()
    {
        T obj = Object.Instantiate(prefab, parent);
        obj.gameObject.SetActive(false);
        availablePool.Add(obj);
        return obj;
    }
    public T GetObjectFromPool()
    {
        var item = availablePool.Count == 0 ? CreateObject() : availablePool[0];
        availablePool.Remove(item);
        return item;
    }

    public void ReturnObjectToPool(T obj)
    {
        availablePool.Add(obj);
    }
}
public class AsteroidPoolManager : Singleton<AsteroidPoolManager>
{
    [SerializeField] Asteroid asteroidPrefab;
    ObjectPool<Asteroid> asteroidPool;
    public static int ActiveAsteriodCount { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        asteroidPool = new ObjectPool<Asteroid>(asteroidPrefab, transform, 4);
    }

    public static Asteroid GetAsteroid(AsteroidSize size, Vector3 pos)
    {
        ActiveAsteriodCount++;
        var asteroid = Instance.asteroidPool.GetObjectFromPool();
        asteroid.transform.position = pos;
        asteroid.SetSize(size);
        asteroid.gameObject.SetActive(true);
        return asteroid;
    }
    public static void ReturnAsteroidToPool(Asteroid asteroid)
    {
        ActiveAsteriodCount--;
        asteroid.Reset();
        Instance.asteroidPool.ReturnObjectToPool(asteroid);
    }
}
