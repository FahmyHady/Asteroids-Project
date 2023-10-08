using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AsteroidSize { Manageable, OhMan, WeAreDead }
public class Asteroid : MonoBehaviour
{
    [SerializeField] Mesh[] possibleMeshes;
    [SerializeField] MeshFilter myFilter;
    [field: SerializeField] public AsteroidSize MySize { get; private set; }
    internal AsteroidHealthComponent healthComponent;
    private void Awake()
    {
        healthComponent = gameObject.GetComponent<AsteroidHealthComponent>();
    }
    public void Reset()
    {
        healthComponent.Reset();
    }
    private void OnEnable()
    {
        myFilter.mesh = possibleMeshes.GetRandomElement();
    }
    public void SetSize(AsteroidSize size)
    {
        MySize = size;
        switch (MySize)
        {
            case AsteroidSize.Manageable:
                transform.localScale = Vector3.one * 4;
                break;
            case AsteroidSize.OhMan:
                transform.localScale = Vector3.one * 8;
                break;
            case AsteroidSize.WeAreDead:
                transform.localScale = Vector3.one * 16;
                break;
        }
    }
}
