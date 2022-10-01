using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    private Rigidbody astRigid;

    private void Start()
    {
        astRigid = GetComponent<Rigidbody>();
        AstMove();
    }
    private void AstMove()
    {
        for (int i = 0; i < 3; i++)
        { 
            astRigid.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        }
    }
}
