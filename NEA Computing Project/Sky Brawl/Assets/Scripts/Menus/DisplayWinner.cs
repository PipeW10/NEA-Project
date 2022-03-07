using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWinner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(PlayerManager.winner, new Vector3(4, 0, -2), Quaternion.identity);
    }
}
