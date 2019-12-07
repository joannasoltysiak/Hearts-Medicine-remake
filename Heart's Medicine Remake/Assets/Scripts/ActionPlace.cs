using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlace : MonoBehaviour
{
    public PlaceType type;
    public Client client;

    //public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        client = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.Log(Physics.Raycast(ray, out hit));
            Debug.Log("Chcecking:" + hit.collider.tag);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Chcecking:" + hit.collider.tag);

                if (hit.collider.tag == this.tag)
                {
                    Debug.Log("My object is clicked by mouse" + hit.collider.tag);
                    
                }
            }
        }
    }

    public void ifClicked()
    {

    }
}

public enum PlaceType
{
    Bed,            //place for Client to lay down -> bed actions
    WaitingSeats,   //place where Client wait to be picked
    Reception,      //where Client wait to pay
    Chair           //place for Client to sit -> chair actions
}
