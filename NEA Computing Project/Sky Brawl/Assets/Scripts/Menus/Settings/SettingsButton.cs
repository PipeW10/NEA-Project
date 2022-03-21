using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] bool powerUpSquare;
    [SerializeField] SettingsManager manager;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Token>() != null)
        {
            manager.SetSettings(powerUpSquare, true);
            sprite.color = Color.green;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Token>() != null)
        {
            manager.SetSettings(powerUpSquare, false);
            sprite.color = Color.red;
        }
    }
}
