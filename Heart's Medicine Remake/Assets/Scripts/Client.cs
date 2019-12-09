using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Client : MonoBehaviour
{
    public ClientState state;

    Vector2 currentPosition;
    Vector3 targetPosition;
    ActionPlace targetPlace;
    public SpriteRenderer bubble;

    public Actions activeAction;
    int numberOfActions;
    public bool canBeChoosed;

    public PlaceType wantedPlace;
    AIDestinationSetter pathfindingTarget;

    // Start is called before the first frame update
    void Start()
    {
        state = ClientState.WaitingToBePlaced;
        activeAction = Actions.None;

        currentPosition = transform.position;
        pathfindingTarget = GetComponent<AIDestinationSetter>();

        if (Random.Range(0, 2) == 0)
            wantedPlace = PlaceType.Bed;
        else
            wantedPlace = PlaceType.Chair;

        ChangeBubble();

        numberOfActions = Random.Range(1, 3);
        canBeChoosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(targetPosition, transform.position) < 1.5f && state == ClientState.Walking) // we have to change target to the place next to the place
        {
            state = ClientState.WaitingForAction;
            pathfindingTarget.target = transform;
            targetPosition = Vector3.zero;

            transform.parent = targetPlace.transform;
        }

        if (state == ClientState.WaitingForAction && wantedPlace == PlaceType.Reception)
        {
            //first he needs to walk towards next place in line before getting added to list of clients standing in front of Reception/Checkout

            state = ClientState.WaitingToPay;
            Debug.Log("You should bring me to checkout now");

            ChangeBubble();

            //so this should be after walking (and client should be added only once)
            //Reception.AddNewClient(this);
        }

        if(state == ClientState.WaitingToPay)
        {
            
        }

    }

    public void ActionDone() 
    {
        numberOfActions--;
    }

    public bool NeedsMoreAction()   //checikng if client needs more actions
    {
        if (numberOfActions == 0)    //if he doesn't need any more actions
        {
            canBeChoosed = false;               //player can't choose him anymore
            activeAction = Actions.None;        //so that no more action would be generated

            return false;
        }
        return true;
    }

    public void SetTargetPosition(Transform position, ActionPlace targetPlace)
    {
        this.targetPlace = targetPlace;
        targetPosition = position.position;
        pathfindingTarget.target = position;


        state = ClientState.Walking;
        ChangeBubble();
    }

    public void ChangeBubble()
    {
        switch (wantedPlace)
        {
            case PlaceType.Bed:
                bubble.color = new Color(255, 0, 0, 255);
                break;
            case PlaceType.Chair:
                bubble.color = new Color(0, 0, 255, 255);
                break;
            case PlaceType.Reception:
                bubble.color = new Color(0, 255, 255, 255);
                break;
        }

        switch (activeAction) // colour is placeholder for graphics
        {
            case Actions.DoCheckup:
                bubble.color = new Color(0, 0, 0, 255);
                break;
            case Actions.CheckTemperature:
                bubble.color = new Color(0, 255, 0, 255);
                break;
        }

        if (state == ClientState.Walking)
            bubble.color = new Color(0, 0, 0, 0);
    }
    

}

public enum ClientState
{
    Walking,                //action done
    WaitingToBePlaced,      //after reaching this state the first timer goes on
    WaitingForAction,       //after being in the right place the timer for action
    WaitingToPay,           //no timer, last state

}