using UnityEngine;

public class CapsuleSpawner : MonoBehaviour
{
    public GameObject capsulePrefab;
    public int maxCapsuleCount = 100;

    private ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.instance;
        objectPooler.CreatePool(capsulePrefab, maxCapsuleCount);
    }

    void FixedUpdate()
    {
        objectPooler.Reuse(capsulePrefab, transform.position, Quaternion.identity, transform);
    }
}
