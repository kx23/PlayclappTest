using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube: MonoBehaviour
{
    public float Limit { get; set; }
    public float Speed { get; set; }
    private void Update()
    {
        if (transform.position.z >= Limit)
        {
            Destroy(gameObject);
        }
        transform.position+= transform.forward*Speed*Time.deltaTime;
    }
}
