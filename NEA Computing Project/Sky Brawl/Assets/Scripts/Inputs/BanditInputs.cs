using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BanditInputs : CharacterInputs
{
    private PlayerMelee melee;
    private PlayerSpinAttack spinAttack;

    private void Awake()
    {
        melee = GetComponent<PlayerMelee>();
        spinAttack = GetComponent<PlayerSpinAttack>();
    }

    public void Fire1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            melee.MeleeAttack();
        }
    }
    public void Fire2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(spinAttack.SpinAttack());
        }
    }
}