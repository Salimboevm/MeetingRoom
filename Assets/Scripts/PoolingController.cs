
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PoolingController : MonoBehaviour
{
    private List<GameObject> _pooledObjects;
    [SerializeField]
    private GameObject _objectToPool;
    [SerializeField]
    private Transform _parent;
    [SerializeField]
    int max;

    public GameObject ObjectToPool { get => _objectToPool;private set => _objectToPool = value; }
    public List<GameObject> PooledObjects { get => _pooledObjects;private set => _pooledObjects = value; }
    public Transform Parent { get => _parent; private set => _parent = value; }

    void OnEnable()
    {
        PooledObjects = new List<GameObject>();
        for (int i = 0; i < max; i++)
        {
            CreateObject();
        }

    }

    void CreateObject()
    {
        GameObject obj;
        obj = Instantiate(ObjectToPool, Parent); 
        obj.SetActive(false);
        PooledObjects.Add(obj);
    }

    public GameObject GetPooledObjects()
    {
        
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
                return PooledObjects[i];

        }
        return null;
    }

    public Transform AcitvatePooledObject(Transform parentC)
    {
       
        GameObject chair = GetPooledObjects();
        if (chair != null)
        {
            chair.transform.parent = null;
            chair.transform.SetParent(parentC);
            chair.SetActive(true);
            return chair.transform;
        }
        return null;
    }
}
