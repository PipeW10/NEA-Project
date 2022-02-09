using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputs : MonoBehaviour
{
    private int characterNumber;
    [SerializeField] private Player player;
    private AlienInputs alienInputs;
    private BanditInputs banditInputs;
    private ArcherInputs archerInputs;

    // Start is called before the first frame update
    private void Start()
    { 
        //Calls the SetSpecificInputs Method
        SetSpecifInputs();
    }

    //Used to find which type of character the gameObject is and links the relevant input script
    private void SetSpecifInputs()
    {
        //Checks the name of the character fromt the player script
        if (player.characterName == "Bandit")
        {
            //Sets the character number so switch cases can be used
            characterNumber = 1;
            banditInputs = GetComponent<BanditInputs>();
        }
        else if (player.characterName == "Alien")
        {
            //Sets the character number so switch cases can be used
            characterNumber = 2;
            alienInputs = GetComponent<AlienInputs>();
        }
        else if (player.characterName == "Archer")
        {
            //Sets the character number so switch cases can be used
            characterNumber = 3;
            archerInputs = GetComponent<ArcherInputs>();
        }
    }

    //Called from the PlayerInputHandler whenever the Fire1 action occurs
    public void Fire1(InputAction.CallbackContext context)
    {
        //Swicth case based on the characterNumber
        //Calls the Fire1 method from the relevant input script
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
    //Called from the PlayerInputHandler whenever the Fire2 action occurs
    public void Fire2(InputAction.CallbackContext context)
    {
        //Swicth case based on the characterNumber
        //Calls the Fire2 method from the relevant input script
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
