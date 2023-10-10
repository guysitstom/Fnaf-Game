using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 Movement = new Vector3(0f, 0f,-5f);



    
    void Start()
    {
        rb.velocity = Movement;
    }
}
