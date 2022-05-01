using UnityEngine;

public class CageWalls : MonoBehaviour
{   
    //This subroutine is called when the object collides with a trigger
    //Trigger collisions don't physically make the player react (eg. move or block the player) but can be detected
    //This is used so the players don't interact with the cage walls
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If a player collides with a part from the map cage, they die
        if (collision.gameObject.layer == 6) 
        {
            StartCoroutine(collision.gameObject.GetComponent<PlayerHealth>().Die());
        }
    }
}
