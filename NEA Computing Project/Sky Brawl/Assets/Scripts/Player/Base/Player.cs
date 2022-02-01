using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public float coolDownTimer;
    [SerializeField] public string characterName;

    //Makes it so that the player can only attack again once enough time has elapsed
    public bool CoolDownCounter(float coolDownTime)
    {
        //Increses the counter by the amount of time elapsed
        coolDownTimer += Time.deltaTime;
        if (coolDownTimer >= coolDownTime)
        {
            //Enables the player's attack
            return true;
        }
        return false;
    }

    public bool CheckInput()
    {
        return true;
    }
}
