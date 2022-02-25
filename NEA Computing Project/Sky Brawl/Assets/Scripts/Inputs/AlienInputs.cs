using UnityEngine.InputSystem;
using UnityEngine;

public class AlienInputs : MonoBehaviour
{
    private PlayerLaser laser;
    private PlayerShot shot;

    // Start is called before the first frame update
    private void Start()
    {
        //Sets the variables laser and shot to the character's PlayerLaser and PlayerShot Components in order to easily access variables
        laser = GetComponent<PlayerLaser>();
        shot = GetComponent<PlayerShot>();
    }

    //Called from character inputs
    public void Fire1(InputAction.CallbackContext context)
    {
        //If the action was performed
        if (context.performed)
        {
            //Calls the FireShot method from the shot script
            shot.FireShot();
        }
    }
    //Called from character inputs
    public void Fire2(InputAction.CallbackContext context)
    {
        //If the action was performed
        if (context.performed)
        {
            //Calls the FireLaser method from the laser script
            StartCoroutine(laser.FireLaser());
        }
    }
}
