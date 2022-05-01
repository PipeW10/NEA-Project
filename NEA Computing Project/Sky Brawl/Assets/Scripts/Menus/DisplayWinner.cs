using UnityEngine;
using TMPro;

public class DisplayWinner : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] playerStatsText;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiates the winner gameobject stored in the player manager once the win screen loads
        Instantiate(PlayerManager.winner, new Vector3(4, 0, -2), Quaternion.identity);
        DisplayStats();

    }

    //Displays the players' stats at the end of a match in the win screen
    private void DisplayStats()
    {
        //Changes the text using the damageStats array in the player manager
        playerStatsText[0].text = "Player 1: " + PlayerManager.damageStats[0].ToString();
        playerStatsText[1].text = "Player 2: " + PlayerManager.damageStats[1].ToString();
        playerStatsText[2].text = "Player 3: " + PlayerManager.damageStats[2].ToString();
        playerStatsText[3].text = "Player 4: " + PlayerManager.damageStats[3].ToString();
    }
}
