using UnityEngine;
using Cinemachine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private bool isSpeedBuff;
    private CinemachineTargetGroup targetGroup;
    
    // Start is called before the first frame update
    private void Start()
    {
        //Calls the AddToTargetGroup method
        AddToTargetGroup();
    }

    //Detects when the powerup collides with anything
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Tries to find a playerPowerUps script on the object that collided with the powerup
        PlayerPowerUps playerPower = collision.collider.GetComponent<PlayerPowerUps>();
        //If the script is found
        if (playerPower != null)
        {
            //If this powerup is a speed powerup
            if (isSpeedBuff)
            {
                //The player's speed is buffed from the PlayerPowerUps script
                playerPower.BuffMoveSpeed();
            }
            //If this powerup is a damage powerup
            else
            {
                //The player's damage is buffed from the PlayerPowerUps script
                playerPower.BuffDamage();
            }
            //Calls the RemoveFromTargetGroup method
            RemoveFromTargetGroup();
            Destroy(gameObject);
        }
    }

    //Removes the powerup from the camera target group
    private void RemoveFromTargetGroup()
    {   
        //Checks to see that the targetgroup is not null and the powerup is a part of it
        if (targetGroup.FindMember(gameObject.transform) != -1 && targetGroup != null)
        {
            //Removes the powerup from the camera target group
            targetGroup.RemoveMember(gameObject.transform);
        }
    }

    //Adds the powerup to the camera target group and sets the weight and radius
    private void AddToTargetGroup()
    {
        targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        targetGroup.AddMember(gameObject.transform, 1, 1);
    }
}
