using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectShipButtons : MonoBehaviour
{
    private DataPreservation dataPreservation;
    private void Start()
    {
        dataPreservation = GameObject.Find("DataPreservation").GetComponent<DataPreservation>();
    }
    public void StartGameButton()
    {
        dataPreservation.SelectedShipMemory();
        SceneManager.LoadScene(2); 
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
