using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicHandler : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip firstOST;
    public AudioClip otherOST;
    private GameManager gameManager;
    // DON'T remove these two bools. Or update function turns the music into a dust.
    private bool firstOSTPlaying = false;
    private bool otherOSTPlaying = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            if (!gameManager.gameOverCheck && !otherOSTPlaying)
            {
                audioSource.Stop();
                audioSource.clip = otherOST;
                firstOSTPlaying = false;
                otherOSTPlaying = true;
                audioSource.Play();
            }
            else if(gameManager.gameOverCheck)
            {
                audioSource.Stop();
            }
        }
        else if (!firstOSTPlaying) 
        {
            audioSource.Stop();
            audioSource.clip = firstOST;
            firstOSTPlaying = true;
            otherOSTPlaying = false;
            audioSource.Play(); 
        }
    }
}
