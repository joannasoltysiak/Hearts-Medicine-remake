using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Client : MonoBehaviour
{
    public ClientState state;

    Vector2 currentPosition;
    AIDestinationSetter pathfindingTarget;



    // Start is called before the first frame update
    void Start()
    {
        state = ClientState.Walking;

        currentPosition = transform.position;
        pathfindingTarget = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        //if()
        
    }

    public void SetTargetPosition(Transform position)
    {
        pathfindingTarget.target = position;
    }
    
    
}

public enum ClientState
{
    Walking,                //action done
    WaitingToBePlaced,      //after reaching this state the first timer goes on
    WaitingForAction,       //after being in the right place the timer for action
    WaitingToPay,           //no timer, last state

}