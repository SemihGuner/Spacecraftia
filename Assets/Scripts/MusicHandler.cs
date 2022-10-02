using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicHandler : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip firstOST;
    public AudioClip otherOST;
    private bool firstOstPlaying = true;
    private bool otherOstPlaying = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2) && !otherOstPlaying)
        {
            audioSource.Stop();
            audioSource.clip = otherOST;
            audioSource.Play();
            otherOstPlaying = true;
            firstOstPlaying = false;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0) && !firstOstPlaying)
        {
            audioSource.Stop();
            audioSource.clip = firstOST;
            audioSource.Play();
            firstOstPlaying = true;
            otherOstPlaying = false;
        }
    }
}
