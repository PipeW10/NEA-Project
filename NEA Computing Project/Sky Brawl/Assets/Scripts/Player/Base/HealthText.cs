using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    [Header("Text Links")]
    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private GameObject livesPrefab;
    private TextMeshProUGUI healthText;
    private TextMeshProUGUI livesText;
    private GameObject characterFace;
    private Canvas canvas;

    // Start is called before the first frame update
    private void Awake()
    {
        //Finds an object in the scene of type canvas
        canvas = FindObjectOfType<Canvas>();
        //Instatiates both the health text and lives text using the prefabs
        healthText = Instantiate(healthPrefab.GetComponent<TextMeshProUGUI>(), transform);
        livesText = Instantiate(livesPrefab.GetComponent<TextMeshProUGUI>(), transform);

        //Sets the livesText and healthtext as children of the canvas so they act as intended
        healthText.transform.SetParent(canvas.gameObject.transform, false);
        livesText.transform.SetParent(canvas.gameObject.transform, false);
    }

    //Update the text which displays the player's health
    public void UpdateHealth(float playerHealth)
    {
        healthText.GetComponent<TextMeshProUGUI>().text = Mathf.Round(playerHealth).ToString() + "%";
    }

    //Update the text which displays the player's lives
    public void UpdateLives(int playerLives)
    {
        livesText.GetComponent<TextMeshProUGUI>().text = playerLives.ToString();
    }
}
