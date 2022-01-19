using UnityEngine;
using UnityEngine.InputSystem;

public class PointClick : MonoBehaviour
{
    private MasterControls playerControls;
    private Mouse mouse;
    private InputAction drag, click;
    private GameObject currentToken;

    private void OnEnable()
    {
        playerControls.Selection.Enable();
    }

    private void OnDisable()
    {
        playerControls.Selection.Disable();
    }

    private void Awake()
    {
        playerControls = new MasterControls();
        InputActionMap selectionMap = playerControls.Selection;
        click = selectionMap.FindAction("Click", true);
        click.started += StartDrag;
        click.canceled += EndDrag;
        drag = selectionMap.FindAction("Drag", true);
        mouse = Mouse.current;
    }

    private void StartDrag(InputAction.CallbackContext context)
    {
        if (Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mouse.position.ReadValue()), Vector2.zero))
        {
           RaycastHit2D objectHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mouse.position.ReadValue()), Vector2.zero);
           GameObject tokenHit = objectHit.collider.gameObject;
           if (tokenHit.GetComponent<Token>() != null)
           {
                currentToken = tokenHit;
                drag.performed += Drag;
           }
        }
    }

    private void EndDrag(InputAction.CallbackContext context)
    {
        Debug.Log("cancelde");
        currentToken = null;
        drag.performed -= Drag;
    }

    private void Drag(InputAction.CallbackContext context)
    {
        if (currentToken != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
            currentToken.transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }
    }

}
