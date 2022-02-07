using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    private GameObject face;

    //Displays the chosen characters face in the box
    public void DisplayChoice(GameObject choice)
    {
        //Creates a new gameObject for the face in the desired position
        face = Instantiate(choice, transform.position, Quaternion.identity);
        //Scales the face up by a set amount
        face.transform.localScale += new Vector3 (1,1,0);
    }

    //Stops displaying the characters face
    public void RemoveChoice()
    {
        //Only is their is a face stored
        if(face != null)
        {
            //Destryos the face GameObject
            Destroy(face);
        }
    }
}
