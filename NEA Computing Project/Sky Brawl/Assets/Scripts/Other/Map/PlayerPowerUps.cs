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
        //If the player currently has a powerup enabled
        if(isSpeedBuffed || isDamageBuffed)
        {
            //Calls the BuffTimeCounter method
            BuffTimeCounter();
        }
    }

    //Responsible for enabling the speed power-up
    public void BuffMoveSpeed()
    {
        //Sets the isSpeedBuffed variable to true
        isSpeedBuffed = true;
        //Changes the value of the move speed in the player controller
        controller.SetMoveSpeed(speedBuff * baseMoveSpeed);
        //Changes the character's colour to yellow
        spriteRenderer.color = Color.yellow;
    }

    //Responsible for enabling the damage power-up
    //Power-up is applied on the player healt script
    public void BuffDamage()
    {
        //Sets the isDamageBuffed variable to true
        isDamageBuffed = true;
        //Changes the character's colour to yellow
        spriteRenderer.color = Color.red;
    }

    //Used to revert all power-ups the player currently has enabled
    private void EndBuffs()
    {
        //Sets the isDamageBuffed and the isSpeedBuffed variable to false
        isSpeedBuffed = false;
        isDamageBuffed = false;
        //Changes the back to move speed in the player controller back to normal
        controller.SetMoveSpeed(baseMoveSpeed);
        //Changes the character's colour to white (normal)
        spriteRenderer.color = Color.white;
    }

    //Makes it so that the player only has the chaacter for a set amount of time
    private void BuffTimeCounter()
    {
        //Increses the counter by the amount of time elapsed
        buffTimer += Time.deltaTime;
        //If enough time has elapsed
        if (buffTimer >= buffTime)
        {
            //Turns the powerup off 
            EndBuffs();
            //Resets the timer for next time
            buffTimer = 0;
        }
    }
}
