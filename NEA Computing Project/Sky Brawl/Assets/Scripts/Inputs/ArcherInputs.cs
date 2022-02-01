using UnityEngine.InputSystem;

public class ArcherInputs : CharacterInputs
{
    private ArcherShot archerShot;

    private void Awake()
    {
        archerShot = GetComponent<ArcherShot>();
    }

    public void Fire1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            archerShot.FireArrow(archerShot.basicArrow);
        }
    }
    public void Fire2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            archerShot.FireArrow(archerShot.stickyArrow);
        }
    }
}
