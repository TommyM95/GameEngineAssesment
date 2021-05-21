using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnemyBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform FiringPoint;
    public float speed = 100f;

    public Transform target;
    private float distanceToTarget;

    private float timeBetweenShots = 1f;
    private float shotDelayTime;

    private void Awake()
    {
        
    }

    private void Update()
    {
        shotDelayTime -= Time.deltaTime;

        AquireTarget();

        if (distanceToTarget < 5 && shotDelayTime <= 0f)
        {
            FireBullet();
            shotDelayTime = timeBetweenShots;
        }
    }
    public void AquireTarget()
    {
        if (target == null)
        {
            return;
            //target = FindObjectOfType FindObjectOfType<scr_CharacterController>().transform;
        }

        distanceToTarget = Vector3.Distance(target.transform.position, this.transform.position);
    }

    public void FireBullet()
    {
        GameObject instBullet = Instantiate(bullet, FiringPoint.position, Quaternion.identity);
        Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidbody.AddForce(FiringPoint.forward * speed);
    }

}
