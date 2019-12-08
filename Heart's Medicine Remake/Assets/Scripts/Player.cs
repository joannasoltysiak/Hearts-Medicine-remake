using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Player : MonoBehaviour
{
    public List<ItemType> itemList; 
    Vector2 currentPosition;
    Vector3 targetPosition;
    AIDestinationSetter pathfindingTarget;

    Client clientToHelp;
    ItemType destinationItem;

    // Start is called before the first frame update
    void Start()
    {
        destinationItem = ItemType.None;
        clientToHelp = null;
        itemList = new List<ItemType>();
        currentPosition = transform.position;
        pathfindingTarget = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(targetPosition, transform.position) < 1.5f) // problem with thissss
        {
            pathfindingTarget.target = transform;
            targetPosition = Vector3.zero;

            if(destinationItem != ItemType.None)
            {
                if (itemList.Count < 3)
                {
                    Debug.Log("ITEM ADDED");
                    itemList.Add(destinationItem);
                    destinationItem = ItemType.None;
                }
            }

            if(clientToHelp != null)
            {
                bool isHelped = CheckHelp();
                if (isHelped)
                {
                    clientToHelp.activeAction = Actions.None;
                    clientToHelp.state = ClientState.WaitingToBePlaced;
                    if (Random.Range(0, 2) == 0)
                        clientToHelp.wantedPlace = PlaceType.Bed;
                    else
                        clientToHelp.wantedPlace = PlaceType.Chair;
                    clientToHelp.ChangeBubble();
                }
                clientToHelp = null;
            }
        }
    }

    bool CheckHelp()
    {
        switch (clientToHelp.activeAction)
        {
            case Actions.CheckTemperature:
                for(int i = 0; i < itemList.Count; i++)
                {
                    if(itemList[i] == ItemType.Termometer)
                    {
                        itemList.Remove(itemList[i]);
                        return true;
                    }
                }
                return false;
            case Actions.DoCheckup:
                return true;
            default:
                return false;
        }
    }

    public void SetTargetPosition(Transform position, Client clientToHelp, ItemType destinationItem)
    {
        targetPosition = position.position;
        pathfindingTarget.target = position;
        this.clientToHelp = clientToHelp;
        this.destinationItem = destinationItem;
    }
}

