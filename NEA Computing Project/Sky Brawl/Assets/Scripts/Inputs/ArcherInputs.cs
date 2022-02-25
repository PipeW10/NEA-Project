using UnityEngine.InputSystem;
using UnityEngine;

public class ArcherInputs : MonoBehaviour
{
    private ArcherShot archerShot;

    // Start is called before the first frame update
    private void Start()
    {
        archerShot = GetComponent<ArcherShot>();
    }
    //Called from character inputs
    public void Fire1(InputAction.CallbackContext context)
    {
        //If the action was performed
        if (context.performed)
        {
            //Calls the FireArrow method from the Archer Shot script with basicarrow as a parameter
            archerShot.FireArrow(archerShot.basicArrow);
        }
    }
    //Called from character inputs
    public void Fire2(InputAction.CallbackContext context)
    {
        //If the action was performed
        if (context.performed)
        {
            //Calls the FireArrow method from the Archer Shot script with stickyarrow as a parameter
            archerShot.FireArrow(archerShot.stickyArrow);
        }
    }
}
