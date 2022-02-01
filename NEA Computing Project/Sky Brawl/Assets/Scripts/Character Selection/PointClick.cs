using UnityEngine;
using UnityEngine.InputSystem;

public class PointClick : MonoBehaviour
{
    private MasterControls playerControls;
    private Mouse mouse;
    private InputAction drag, click;
    private GameObject currentToken;
    private bool mouseOnReady;
    [SerializeField] ReadyButton readyButton;

    //Called after awake or whenever the script is enabled
    private void OnEnable()
    {
        //Enables the Selection Ipnut action map so this script can detect certain inputs
        playerControls.Selection.Enable();
    }

    //Called whenever the script is disabled
    private void OnDisable()
    {
        //Disables the Selection input action map
        playerControls.Selection.Disable();
    }

    //First Method to be called in the script
    private void Awake()
    {
        //Sets the playercontrols variable to a reference for the master controls script
        playerControls = new MasterControls();
        //Creates a reference of the selection input action map
        InputActionMap selectionMap = playerControls.Selection;
        //Links Inputs from the selection input action map to specified sub-routines so action may be performed
        click = selectionMap.FindAction("Click", true);
        click.started += StartDrag;
        click.canceled += EndDrag;
        drag = selectionMap.FindAction("Drag", true);
        //Sets the mouse variable to the mouse currently in use
        mouse = Mouse.current;
        mouseOnReady = false;
    }

    //Is called whenever the click action is performed
    private void StartDrag(InputAction.CallbackContext context)
    {
        //Checks whether the mouse is direclty above a game object
        if (Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mouse.position.ReadValue()), Vector2.zero))
        {
           //Sets the object hit variable to whatever game object the mouse is above
           GameObject objectHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mouse.position.ReadValue()), Vector2.zero).collider.gameObject;
           //Checks whether the object hit game object has a token script (Is a token)
           if (objectHit.GetComponent<Token>() != null)
           {
                //If so, sets currenToken to token hit 
                currentToken = objectHit;
                //and links the Drag method to the drag action
                drag.performed += Drag;
           }
           //Else, checks whether the object was the ready button
           else if(objectHit == readyButton.gameObject)
           {
                //Sets mouseOnReady to true
                mouseOnReady = true;
           }
        }
    }

    //Called when the click action is canceled
    private void EndDrag(InputAction.CallbackContext context)
    {
        //If current token is not null
        if (currentToken != null)
        {
            //Sets currentToken to null
            currentToken = null;
            drag.performed -= Drag;
        }
        //Else if the mouseOnReady variable is true
        else if (mouseOnReady)
        {
            //Calls the loadMap method from the readyButton script
            readyButton.LoadMap();
        }
        //Un-links the drag method from the drag aciton
    }

    private void Drag(InputAction.CallbackContext context)
    {
        //If current token is not null
        if (currentToken != null)
        {
            //Sets the position of the token to the position of the mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
            currentToken.transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }
    }
}
