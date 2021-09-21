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

        //If the shield button is held down and teh shield is currently off ShieldOn is called
        if (Input.GetButton("Shield") && isShieldOn == false 
            && GetComponent<KnockBackEffect>().isKnockedBack == false 
            && shieldTimer < shieldMaxTime )
        {
            ShieldOn();
        }

        //If the shield button is released and the shield is on ShieldOff is called
        if (Input.GetButtonUp("Shield"))
        {
            ShieldOff();
        }

        if(isShieldOn)
        {
            ShieldDegeneration();
        }
    }

    private void ShieldDegeneration()
    {
        shieldTimer += Time.deltaTime;
        if (shieldTimer >= shieldMaxTime)
        {
            ShieldOff();
        }
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
        if (!Input.GetButton("Shield"))
        {
            //Resets the shield timer
            shieldTimer = 0;
        }
    }
}
