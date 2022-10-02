using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Spaceship is the one gets selected.
    private GameObject spaceship;
    public List<GameObject> asteroids = new List<GameObject>();
    private Vector3 startPos = new Vector3(0, 0, -90);
    private AudioSource AudioSource;
    public AudioClip ShootingClip;
    public AudioClip GameOverClip;
    void Start()
    {
        //These are for positioning the selected ship.
        spaceship = GameObject.FindWithTag("Spaceship");
        AudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        spaceship.transform.position = startPos;
        spaceship.transform.Rotate(0, -180, 0);
        spaceship.AddComponent<PlayerController>();
        //Asteroids gets spawned every 3 seconds.
        InvokeRepeating("AsteroidSpawner", 0.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AsteroidSpawner()
    {
        int rng = Random.Range(0, 3);
        Instantiate(asteroids[rng], AstSpawnLocation(), asteroids[rng].transform.rotation);
    }
    protected Vector3 AstSpawnLocation()
    {
        float XLoc = Random.Range(-245.0f, 250.0f);
        return new Vector3(XLoc, 0, 160);
    }
    public void GameOver()
    {
        Debug.Log("Game over"); 
        AudioSource.PlayOneShot(GameOverClip, 1.0f);
        CancelInvoke();
        SceneManager.LoadScene(0);
    }
}
