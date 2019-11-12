using UnityEngine;

public class Capsule : MonoBehaviour, IReusable
{
    private float force = 100;
    private float torque = 100;

    private Rigidbody rb;
    private Renderer rend;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    public void Reuse()
    {
        rb.AddForce(Random.insideUnitSphere * force);
        rb.AddTorque(Random.insideUnitSphere * torque);

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rend.material.color = Random.ColorHSV();
    }
}
