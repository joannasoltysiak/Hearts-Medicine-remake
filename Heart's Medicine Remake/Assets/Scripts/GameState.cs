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
        if (Input.GetMouseButtonDown(0))
        {
            DoRaycast();
        }
    }

    void DoRaycast()
    {
         RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
         Debug.Log(hit.collider.tag);
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
                    //set active client target to this, then move client, if no client active, then player go, check if place is taken
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
