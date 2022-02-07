using UnityEngine;

public class MapToken : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private MapManager mapManager;

    //Called when a gameobject with a collider enter the box collider on the button
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Sets the MapButton component on the collider to the button variable
        MapButton button = collision.gameObject.GetComponent<MapButton>();
        //If a MapButton component was found
        if (button != null)
        {
            //Sets the map in the playerManager
            playerManager.SetMap(button.mapName);
            //Sets the map in teh mapManager
            mapManager.SetMap(button.mapName);
        }
    }

    //Called when a gamobject with a collider exits the box collider on the button
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Sets the MapButton component on the collider to the button variable
        MapButton button = collision.gameObject.GetComponent<MapButton>();
        //If a MapButton component was found
        if (button != null)
        {
            //Resets the map in the playerManager
            playerManager.ResetMap(button.mapName);
            //Resets the map in the mapManager
            mapManager.ResetMap(button.mapName);
        }
    }
}
