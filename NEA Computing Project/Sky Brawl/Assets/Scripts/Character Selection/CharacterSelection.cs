using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private int numberPlayers;

    [Header("Buttons")]
    [SerializeField] Button archerButton;

    public int GetNumberOfPlayer()
    {
        return numberPlayers;
    }
}
