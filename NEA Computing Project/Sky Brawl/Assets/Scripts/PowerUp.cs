using UnityEngine;
using Cinemachine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private bool isSpeedBuff;
    private CinemachineTargetGroup targetGroup;

    private void Start()
    {
        AddToTargetGroup();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerPowerUps playerPower = collision.collider.GetComponent<PlayerPowerUps>();
        if (playerPower != null)
        {
            if (isSpeedBuff)
            {
                playerPower.BuffMoveSpeed();
            }
            else
            {
                playerPower.BuffDamage();
            }
            RemoveFromTargetGroup();
            Destroy(gameObject);
        }
    }

    //Removes the gameobject from the camera target group
    private void RemoveFromTargetGroup()
    {    
        if (targetGroup.FindMember(gameObject.transform) != -1 && targetGroup != null)
        {
            targetGroup.RemoveMember(gameObject.transform);
        }
    }

    //Adds the gameobject to the camera target group and sets the weight and radius
    private void AddToTargetGroup()
    {
        targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        targetGroup.AddMember(gameObject.transform, 1, 1);
    }
}
