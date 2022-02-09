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

    //Called from character
    public void Fire1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shot.FireShot();
        }
    }
    public void Fire2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(laser.FireLaser());
        }
    }
}
