using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Player : MonoBehaviour
{
    Item[] itemList; 
    Vector2 currentPosition;
    Vector3 targetPosition;
    AIDestinationSetter pathfindingTarget;

    Client clientToHelp;

    // Start is called before the first frame update
    void Start()
    {
        clientToHelp = null;
        itemList = new Item[3];
        currentPosition = transform.position;
        pathfindingTarget = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(targetPosition, transform.position) < 0.5f)
        {
            pathfindingTarget.target = transform;
            targetPosition = Vector3.zero;

            if(clientToHelp != null)
            {
                
            }
        }
    }

    bool CheckHelp()
    {
        switch (clientToHelp.activeAction)
        {
            case Actions.CheckTemperature:
                return true;
            case Actions.DoCheckup:
                return true;
            default:
                return false;
        }
    }

    public void SetTargetPosition(Transform position, Client clientToHelp)
    {
        targetPosition = position.position;
        pathfindingTarget.target = position;
        this.clientToHelp = clientToHelp;
    }
}

