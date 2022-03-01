using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour 
{
    [SerializeField]
    int _numberOfObjects = 0;
    [SerializeField]
    GameObject _object;

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        StartPool();
    }

    void StartPool()
    {
        for (int i = 0; i < _numberOfObjects; i++)
        {
            AddToPool(Instantiate(_object));
        }
    }

    public void AddToPool(GameObject obj)
    {
        obj.transform.parent = transform;
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    public GameObject GetBullet()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return null;
    }
}
