using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BanditInputs : MonoBehaviour
{
    private PlayerMelee melee;
    private PlayerSpinAttack spinAttack;

    // Start is called before the first frame update
    private void Start()
    {
        melee = GetComponent<PlayerMelee>();
        spinAttack = GetComponent<PlayerSpinAttack>();
    }

    //Called from character inputs
    public void Fire1(InputAction.CallbackContext context)
    {
        //If the action was performed
        if (context.performed)
        {
            //Calls the MeleeAttack method fromthe PlayerMelee script
            melee.MeleeAttack();
        }
    }
    //Called from character inputs
    public void Fire2(InputAction.CallbackContext context)
    {
        //If the action was performed
        if (context.performed)
        {
            //Calls teh SpinAttack method from the PlayerSpinAttack script
            StartCoroutine(spinAttack.SpinAttack());
        }
    }
}
