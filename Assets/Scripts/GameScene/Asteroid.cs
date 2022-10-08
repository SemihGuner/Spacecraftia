using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    private Rigidbody astRigid;
    private GameManager gameManager;

    private void Start()
    {
        astRigid = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        AstMove();
    }
    private void AstMove()
    {
        astRigid.AddForce(Vector3.back * speed, ForceMode.Impulse);
        if (transform.position.z < -200)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spaceship"))
        {
            gameManager.GameOver();
        }
        else
        {
            gameManager.UpdateScore(1);
        }
        Destroy(gameObject);
        Destroy(collision.gameObject);
        Debug.Log("Destroyed");
    }
}
