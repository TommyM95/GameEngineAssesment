using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform FiringPoint;
    public float speed = 100f;

    private void Start()
    {
        FiringPoint = this.GetComponent<Bullet>().transform;
    }

    public void FireBullet()
    {
        if (FiringPoint != null && bullet != null)
        {
            GameObject instBullet = Instantiate(bullet, FiringPoint.position, Quaternion.identity);
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(FiringPoint.forward * speed);
        }
        else
        {
            Debug.Log("firing point and / or bullet returned null");
        }
        
    }

}
