using UnityEngine.InputSystem;
using UnityEngine;

public class AlienInputs : MonoBehaviour
{
    private PlayerLaser laser;
    private PlayerShot shot;

    private void Awake()
    {
        laser = GetComponent<PlayerLaser>();
        shot = GetComponent<PlayerShot>();
    }

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
