using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputs : MonoBehaviour
{
    private int characterNumber;
    private AlienInputs alienInputs;
    private BanditInputs banditInputs;
    private ArcherInputs archerInputs;

    private void Awake()
    {
        if (GetComponent<Player>().characterName == "Bandit")
        {
            characterNumber = 1;
            banditInputs = GetComponent<BanditInputs>();
        }
        else if (GetComponent<Player>().characterName == "Alien")
        {
            characterNumber = 2;
            alienInputs = GetComponent<AlienInputs>();
        }
        else if (GetComponent<Player>().characterName == "Archer")
        {
            characterNumber = 3;
            archerInputs = GetComponent<ArcherInputs>();
        }
    }

    public void Fire1(InputAction.CallbackContext context)
    {
        switch (characterNumber)
        {
            case 1:
                banditInputs.Fire1(context);
                break;
            case 2:
                alienInputs.Fire1(context);
                break;
            case 3:
                archerInputs.Fire1(context);
                break;
        }
    }
    public void Fire2(InputAction.CallbackContext context)
    {
        switch (characterNumber)
        {
            case 1:
                banditInputs.Fire2(context);
                break;
            case 2:
                alienInputs.Fire2(context);
                break;
            case 3:
                archerInputs.Fire2(context);
                break;
        }
    }
}
