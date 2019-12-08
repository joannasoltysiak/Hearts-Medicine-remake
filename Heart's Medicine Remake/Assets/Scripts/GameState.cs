using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public Player player;

    GameObject clickedObject;
    Transform clickedPlace;

    Vector2 mousePosition;

    private void Start()
    {
        clickedObject = null;
        clickedPlace = null;
    }

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
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        Debug.Log(hit.collider.tag);

        switch (hit.collider.tag)
         {
            case "Client":
                clickedPlace = null;
                clickedObject = hit.collider.gameObject;
                //make client active
                break;

            case "Item":
                clickedObject = hit.collider.gameObject;
                clickedPlace = hit.transform;
                player.SetTargetPosition(clickedPlace);
                clickedPlace = null;
                //set players target and when position is okay, take item
                break;

            case "ActionPlace":
                clickedPlace = hit.transform;
                //set active client target to this, then move client, if no client active, then player go, check if place is taken
                if (clickedObject == null || clickedObject.tag == "Item")
                {
                    player.SetTargetPosition(clickedPlace);
                }
                else
                {
                    ActionPlace place = hit.collider.gameObject.GetComponent<ActionPlace>();

                    if (place != null)
                    {
                        if (clickedObject.tag == "Client" && (place.type == PlaceType.Bed || place.type == PlaceType.Chair))
                        {
                            Client client = clickedObject.GetComponent<Client>();
                            if(client.state == ClientState.WaitingToBePlaced)
                                client.SetTargetPosition(clickedPlace, place);
                        }
                    }
                }
                clickedObject = null;
                clickedPlace = null;

                break;

            case "Floor":
                clickedObject = null;
                clickedPlace = hit.transform;
                player.SetTargetPosition(transform);
                clickedPlace = null;
                break;

            default:
                break;
          
        }
    }
}
