using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] bool powerUpSquare;
    [SerializeField] SettingsManager manager;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    //Detects when something enters the button's collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the collider was a token
        if (collision.gameObject.GetComponent<Token>() != null)
        {
            //Calls the SetSettings method from the setting manager
            manager.SetSettings(powerUpSquare, true);
            //Turn the button's colour to green
            sprite.color = Color.green;
        }
    }

    //Detects when something enters the button's collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        //If the collider was a token
        if (collision.gameObject.GetComponent<Token>() != null)
        {
            //Calls the SetSettings method from the setting manager
            manager.SetSettings(powerUpSquare, false);
            //Turn the button's colour to red
            sprite.color = Color.red;
        }
    }
}
