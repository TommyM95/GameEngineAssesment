using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnemyMoveTest : MonoBehaviour
{
    public float torque = 1f;
    public float thrust = 1f;

    public Transform player;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    
    void FixedUpdate()
    {
        Fly();
    }

    void Fly()
    {
        transform.LookAt(player);
        Vector3 targetLocation = player.position - transform.position;
        float distance = targetLocation.magnitude;
        rb.AddRelativeForce(Vector3.forward * Mathf.Clamp((distance - 10) / 10, 0f, 1f)* thrust);

    }
}
