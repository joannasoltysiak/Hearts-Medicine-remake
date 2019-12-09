using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public Player player;
    public static int points;
    public Text pointsInfo;

    GameObject clickedObject;
    Transform clickedPlace;

    Vector2 mousePosition;

    private void Start()
    {
        clickedObject = null;
        clickedPlace = null;
        points = 0;
        pointsInfo.text = "Points: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DoRaycast();
        }

        pointsInfo.text = "Points: " + points;
    }

    void DoRaycast()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        Debug.Log(hit.collider.tag);

        //By raycasting we get objects that we click on, then we classify the object by its tag and we keep it in the memory for actions. Each Object has its own action

        switch (hit.collider.tag)
         {
            case "Client":
                clickedPlace = null;
                clickedObject = hit.collider.gameObject;
                Client client1 = clickedObject.GetComponent<Client>();
                if (client1.state == ClientState.WaitingForAction)
                {
                    player.SetTargetPosition(SetPositionNextToPlace(client1.targetPlace, PositionType.ForPlayer, clickedPlace), client1,ItemType.None);
                }
                break;

            case "Item":
                clickedPlace = hit.transform;
                Item itemPlace = hit.collider.gameObject.GetComponent<Item>();
                player.SetTargetPosition(itemPlace.GetPosition(PositionType.Same), null, itemPlace.item);
                clickedPlace = null;
                break;

            case "ActionPlace":
                clickedPlace = hit.transform;
                ActionPlace place = hit.collider.gameObject.GetComponent<ActionPlace>();
                if (clickedObject == null)//player can come to the place without any action
                {
                    player.SetTargetPosition(SetPositionNextToPlace(place, PositionType.ForPlayer, clickedPlace), null, ItemType.None);
                }
                else if (place.IsTaken()) //player comes over to help the client
                {
                    player.SetTargetPosition(SetPositionNextToPlace(place, PositionType.ForPlayer, clickedPlace), place.GetClient(), ItemType.None);
                }
                else if (place != null)
                {
                    if (clickedObject.tag == "Client" && (place.type == PlaceType.Bed || place.type == PlaceType.Chair))
                    {
                        Client client = clickedObject.GetComponent<Client>();
                        if (client.state == ClientState.WaitingToBePlaced && client.wantedPlace == place.type && !place.IsTaken())//moving client to the specific place
                        {
                            client.SetTargetPosition(SetPositionNextToPlace(place, PositionType.ForClient, clickedPlace), place);
                            place.SetClient(client);
                        }
                        else if(client.state == ClientState.WaitingForAction)//cant move client who is waiting for action
                        {
                            player.SetTargetPosition(SetPositionNextToPlace(place, PositionType.ForPlayer, clickedPlace), null, ItemType.None);
                        }
                    }
                }
                
                clickedObject = null;
                clickedPlace = null;

                break;

            case "Floor":
                clickedObject = null;
                clickedPlace = hit.transform;
                player.SetTargetPosition(transform, null,ItemType.None);
                clickedPlace = null;
                break;

            default:
                break;
          
        }
    }

    Transform SetPositionNextToPlace(ActionPlace place, PositionType position, Transform clickedPlace) //sets position where client or player will stand after clicking this object
    {
        if (place.type == PlaceType.Bed)
        {
            clickedPlace = place.GetPosition(PositionType.Same);
            return clickedPlace;
        }
        else if (place.type == PlaceType.Chair)
        {
            clickedPlace = place.GetPosition(position);
            return clickedPlace;
        }
        else
            return null;
    }
}
