using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    private PlayerController controller;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float baseMoveSpeed;
    [SerializeField] public float speedBuff, damageBuff;
    [SerializeField] private float buffTime, buffTimer;
    [HideInInspector] public bool isSpeedBuffed, isDamageBuffed;


     // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpeedBuffed || isDamageBuffed)
        {
            BuffTimeCounter();
        }
    }

    public void BuffMoveSpeed()
    {
        isSpeedBuffed = true;
        controller.SetMoveSpeed(speedBuff * baseMoveSpeed);
        spriteRenderer.color = Color.yellow;
    }

    public void BuffDamage()
    {
        isDamageBuffed = true;
        spriteRenderer.color = Color.red;
    }

    private void EndBuffs()
    {
        isSpeedBuffed = false;
        isDamageBuffed = false;
        controller.SetMoveSpeed(baseMoveSpeed);
        spriteRenderer.color = Color.white;
    }

    //Makes it so that the player can only attack again once enough time has elapsed
    private void BuffTimeCounter()
    {
        //Increses the counter by the amount of time elapsed
        buffTimer += Time.deltaTime;
        if (buffTimer >= buffTime)
        {
            //Enables the player's attack
            EndBuffs();
            buffTimer = 0;
        }
    }
}
