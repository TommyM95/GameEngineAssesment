using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class LifeTime : MonoBehaviour
{
    public float TimeToLive = 5f;
    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
}
