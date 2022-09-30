using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectShipButtons : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene(2); 
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
