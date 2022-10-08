using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Spaceship is the one gets selected.
    private GameObject spaceship;
    public List<GameObject> asteroids = new List<GameObject>();
    public List<Material> backgrounds = new List<Material>();
    private Vector3 startPos = new Vector3(0, 0, -90);
    [SerializeField] private GameObject GOS;
    private MeshRenderer meshRenderer;
    private AudioSource AudioSource;
    private int score = 0;
    public AudioClip ShootingClip;
    public AudioClip BoomClip;
    public AudioClip GameOverClip;
    private TextMeshProUGUI scoreText;
    public bool gameOverCheck = false;
    void Start()
    {
        //These are for positioning the selected ship.
        spaceship = GameObject.FindWithTag("Spaceship");
        AudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        meshRenderer = GameObject.Find("Background").GetComponent<MeshRenderer>();
        spaceship.transform.position = startPos;
        spaceship.transform.Rotate(0, -180, 0);
        spaceship.AddComponent<PlayerController>();
        SelectBackground();
        //Asteroids gets spawned every 3 seconds.
        InvokeRepeating("AsteroidSpawner", 0.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SelectBackground()
    {
        int a = Random.Range(0, 3);
        meshRenderer.material = backgrounds[a];
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
        GOS.SetActive(true);
        gameOverCheck = true;
    }
    public void UpdateScore(int increase)
    {
        score += increase;
        scoreText.text = "Score: " + score;
    }
    public void ExplosionSound()
    {
        AudioSource.PlayOneShot(BoomClip, 1.0f);
    }
}
