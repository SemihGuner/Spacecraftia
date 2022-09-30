using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public CircularList<GameObject> spaceships;
    // I had to hard code all three locations of ships.
    // I took the circular list code from StackOverflow.
    private CircularList<Vector3> locations = new CircularList<Vector3> { new Vector3(-155, 5, -294), new Vector3(5, 52, -426), new Vector3(155, -5, -294) };
    [SerializeField] private float animationSpeed = 5f;
    [SerializeField] private float height = 0.5f;
    public void SpaceshipFocusedOn(GameObject spaceship)
    {
        // Plays loop animation when ship is selected.
        Vector3 pos;
        pos = spaceship.transform.position;
        float newY = Mathf.Sin(Time.time * animationSpeed) * height + pos.y;
        spaceship.transform.position = new Vector3(spaceship.transform.position.x, newY, spaceship.transform.position.z);
    }
    private void ChangeFocusedShip(char pressedDirection)
    {
        // Changes the focused ship on screen.
        if (pressedDirection == 'a')
        {
            spaceships.Current.transform.position = locations.Next;
            spaceships.Previous.transform.position = locations.Current;
            spaceships.Next.transform.position = locations.Previous;
            spaceships.CurrentIndex = spaceships.PreviousIndex;
           
        }
        else if (pressedDirection == 'd')
        {
            spaceships.Current.transform.position = locations.Previous;
            spaceships.Previous.transform.position = locations.Next;
            spaceships.Next.transform.position = locations.Current;
            spaceships.CurrentIndex = spaceships.NextIndex;

        }
        else
        {
            Debug.Log("Unexpected event in ChangeFocusedShip function. ERR Code: \"Dude, how did you trigger this?\"");
        }
    }
    private void Start()
    {
        spaceships = new CircularList<GameObject> { GameObject.Find("Spaceship #1"), GameObject.Find("Spaceship #2"), GameObject.Find("Spaceship #3") };
        spaceships.CurrentIndex = 1;
        locations.CurrentIndex = 1;
    }
    private void Update()
    {
        /* Checks what the active ship is, and gives it the wobbling effect.
         * If key a or d is clicked, it changes focused ship.
        */
        SpaceshipFocusedOn(spaceships.Current);
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeFocusedShip('a');
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeFocusedShip('d');
        }
    } 
}
