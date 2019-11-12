using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    #region Singleton
    public static ObjectPooler instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [System.Serializable]
    public class Pool
    {
        public int id;
        public GameObject prefab;
        public int size;
    }

    public Dictionary<int, Queue<GameObject>> pools = new Dictionary<int, Queue<GameObject>>();

    public void CreatePool(GameObject prefab, int size)
    {
        if (size <= 0)
        {
            Debug.LogError("Pool size cannot be less than 1");
            return;
        }

        int id = prefab.GetInstanceID();

        if (!pools.ContainsKey(id))
        {
            GameObject poolHolder = new GameObject(prefab.name + "Pool");

            Queue<GameObject> objects = new Queue<GameObject>();
            for (int i = 0; i < size; i++)
            {
                GameObject newObject = Instantiate(prefab, poolHolder.transform);
                newObject.SetActive(false);
                objects.Enqueue(newObject);
            }
            pools.Add(id, objects);
        }
    }

    public GameObject Reuse(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int id = prefab.GetInstanceID();

        if (pools.ContainsKey(id))
        {
            GameObject objectToReuse = pools[id].Dequeue();
            pools[id].Enqueue(objectToReuse);
            objectToReuse.SetActive(true);
            objectToReuse.transform.position = position;
            objectToReuse.transform.rotation = rotation;
            objectToReuse.GetComponent<IReusable>()?.Reuse();
            return objectToReuse;
        }
        Debug.LogWarningFormat("Pool for prefab {0} does not exist", prefab.name);
        return null;
    }

    public GameObject Reuse(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
    {
        GameObject objectToReuse = Reuse(prefab, position, rotation);
        if (objectToReuse)
        {
            objectToReuse.transform.parent = parent;
            return objectToReuse;
        }
        return null;
    }
}
