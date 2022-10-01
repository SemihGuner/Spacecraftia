using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPreservation : MonoBehaviour
{
    // This code holds what ship got selected.
    private Selector selector;
    [SerializeField] private GameObject selectedShip;
    void Start()
    {
        selector = GameObject.Find("Selector").GetComponent<Selector>();
    }
    public void SelectedShipMemory()
    {
        selectedShip = selector.spaceships.Current;
        DontDestroyOnLoad(selectedShip);
    } 
}
