using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    [HideInInspector] public float coolDownTimer;
    [SerializeField] public string characterName;
    private CinemachineTargetGroup targetGroup;
    [SerializeField] private float cameraRadius;
    [SerializeField] public GameObject characterSprite;
    [HideInInspector] public int characterNumber;

    // Start is called before the first frame update
    private void Start()
    {
        //Finds an object in the scene of type CinemachineTargetGroup to be able to use the CMVcam methods
        targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        //Calls the AddToTargetGroup method
        AddToTargetGroup();
        
    }

    //Removes the gameobject from the camera target group
    public void RemoveFromTargetGroup()
    {
        targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        if (targetGroup.FindMember(gameObject.transform) != -1 && targetGroup != null)
        {
            targetGroup.RemoveMember(gameObject.transform);
        }
    }

    //Adds the gameobject to the camera target group and sets the weight and radius
    public void AddToTargetGroup()
    {
        targetGroup.AddMember(gameObject.transform, 1, 4);
    }

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
}
