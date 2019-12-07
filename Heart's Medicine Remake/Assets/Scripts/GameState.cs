using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    GameObject clickedObject;
    Vector2 clickedPlace;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            switch (hit.collider.tag)
            {
                case "Client":
                    clickedPlace = Vector2.zero;
                    clickedObject = hit.collider.gameObject;
                    //make client active
                    break;
                case "Item":
                    clickedObject = hit.collider.gameObject;
                    clickedPlace = hit.transform.position;
                    //set players target and when position is okay, take item
                    break;
                case "ActionPlace":
                    clickedPlace = hit.transform.position;
                    //set active client target to this, then move client
                    clickedObject = null;
                    break;
                case "Floor":
                    clickedObject = null;
                    clickedPlace = hit.transform.position;
                    //set player's target to this, in update move player
                    break;
                default:
                    break;
            }
        }
    }
}
