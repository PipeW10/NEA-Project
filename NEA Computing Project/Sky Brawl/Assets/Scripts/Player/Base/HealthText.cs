using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{

    [Header("Text Links")]
    [SerializeField] private GameObject healthText;
    [SerializeField] private GameObject livesText;
    [SerializeField] private GameObject characterFace;

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
