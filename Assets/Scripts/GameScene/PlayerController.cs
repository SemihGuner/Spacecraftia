using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player controls
    public float HorizontalAxe;
    private Vector3 currentEulerAngles;
    public float Force = 200;
    // Laser
    private GameObject laser;
    // Shooting Audio
    private AudioSource AudioSource;
    private AudioClip ShootingClip; 
    void Start()
    {
        laser = GetComponent<Spaceships>().laserType;
        AudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        ShootingClip = GameObject.Find("GameManager").GetComponent<GameManager>().ShootingClip;
    }
     
    void Update()
    {
        HorizontalAxe = Input.GetAxis("Horizontal");
        BasicControls();
        CheckOutOfBounds();
        Shoot();
    }
    private void BasicControls()
    {
        transform.Translate(Vector3.right * HorizontalAxe * Force * Time.deltaTime);
        if (HorizontalAxe > 0)
        {
            currentEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 15) * Time.deltaTime * 50;
            transform.localEulerAngles = currentEulerAngles;
        }
        else if (HorizontalAxe < 0)
        {
            currentEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -15) * Time.deltaTime * 50;
            transform.localEulerAngles = currentEulerAngles;
        }
        else if (HorizontalAxe == 0)
        {
            currentEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0) * Time.deltaTime * 50;
            transform.localEulerAngles = currentEulerAngles;
        }
    }
    private void CheckOutOfBounds()
    {
        if (transform.position.x < -245)
        {
            transform.position = new Vector3(-245, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 242)
        {
            transform.position = new Vector3(242, transform.position.y, transform.position.z);
        }
        if (transform.position.y != 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laser, new Vector3(transform.position.x, transform.position.y, transform.position.z + 50), transform.rotation);
            AudioSource.PlayOneShot(ShootingClip, 0.5f);
        }
    }
}
