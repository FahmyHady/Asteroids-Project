using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    // Public property to access the instance.
    public static T Instance
    {
        get
        {
            // If the instance is null, try to find an existing instance in the scene.
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                // If no instance exists, create a new GameObject and add the component.
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    instance = singletonObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    // Ensure the instance is not destroyed when reloading the scene.
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
