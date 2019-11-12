# Unity-Object-Pooler
 This is an object pooler project for Unity
 
 ![square](https://user-images.githubusercontent.com/32217921/68706051-36c4e100-05a0-11ea-9136-b5fc3f5f396c.gif)
 
 You can clone or download the project directly, or download the package from releases section and import it to your project.
 
 ## How To Use
 
 Create object pool on ObjectPooler with an object prefab and pool size value
```csharp
    void Start()
    {
        objectPooler = ObjectPooler.instance;
        objectPooler.CreatePool(capsulePrefab, maxCapsuleCount);
    }
```

Reuse from the pool with the same GameObject reference that was used for creating the pool.
Resue method has two overloads. Last transform parameter is for parenting the object. (Like Unity's Instantiate method)
```csharp
    void FixedUpdate()
    {
        objectPooler.Reuse(capsulePrefab, transform.position, Quaternion.identity, transform);
    }
```

If you include IReusable on the reused object class, object pooler will call Reuse method everytime the object is reused.
```csharp
    public class Capsule : MonoBehaviour, IReusable
```

The following is the sample Reuse method
```csharp
    public void Reuse()
    {
        rb.AddForce(Random.insideUnitSphere * force);
        rb.AddTorque(Random.insideUnitSphere * torque);

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rend.material.color = Random.ColorHSV();
    }
```
