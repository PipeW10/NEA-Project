using System;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [HideInInspector]  public bool isShieldOn = false;
   
    private SpriteRenderer sprite;
    private MonoBehaviour playerMovement;
    [Header("Shield Variables")]
    [SerializeField] private float shieldMaxTime;
    private float shieldTimer;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        //If the shield button is held down and the shield is currently off and the timer hasn't surpased the max time allowed, ShieldOn is called
        if (Input.GetButton("Shield") && isShieldOn == false 
            && GetComponent<KnockBackEffect>().isKnockedBack == false 
            && shieldTimer < shieldMaxTime)
        {
            ShieldOn();
        }

        //If the shield button is released and the shield is on ShieldOff is called
        if (Input.GetButtonUp("Shield"))
        {
            ShieldOff();
        }

        //If the shield is on, the shield degeneration subroutine is called
        if(isShieldOn)
        {
            ShieldDegeneration();
        }
        //Else the timer is decreased by the amount of time elapsed so if the shield is turned on just after it has been used, it doesn't last as long
        else if (shieldTimer > 0)
        {
            shieldTimer -= Time.deltaTime;
        }
    }

    //Makes the shield fade away with time
    private void ShieldDegeneration()
    {
        //Adds the time elapsed to the timer
        shieldTimer += Time.deltaTime;
        //If the timer is greater than the maximum shield time allowed the shield is turned off
        if (shieldTimer >= shieldMaxTime)
        {
            ShieldOff();
        }
        //Else the shield colour slowly fades to white as the timer increases
        else
        {
        sprite.color = Color.Lerp(Color.blue, Color.white, shieldTimer / shieldMaxTime);
        }
    }

    //Performs shield animations and disables movement
    //Attacks are disbaled on the attack scripts
    private void ShieldOn()
    {
        isShieldOn = true;
        //Changes the player's colour to blue
        sprite.color = Color.blue;
        //Disables player movement
        playerMovement.enabled = false;
    }

    //Enables movement and stops shield animations
    //Attacks are enabled on the attack scripts
    private void ShieldOff()
    {
        isShieldOn = false;
        //Changes the player's colour back to white
        sprite.color = Color.white;
        //Enables player movement
        playerMovement.enabled = true;
    }
}
