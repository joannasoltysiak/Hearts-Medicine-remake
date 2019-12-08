﻿using System.Collections;
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

    AIDestinationSetter pathfindingTarget;

    // Start is called before the first frame update
    void Start()
    {
        state = ClientState.WaitingToBePlaced;
        activeAction = Actions.None;

        currentPosition = transform.position;
        pathfindingTarget = GetComponent<AIDestinationSetter>();

        numberOfActions = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(targetPosition, transform.position) < 1.5f) // we have to change target to the place next to the place
        {
            state = ClientState.WaitingForAction;
            pathfindingTarget.target = transform;
            targetPosition = Vector3.zero;
            
            targetPlace.SetClient(this);
        }

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
        if (state == ClientState.Walking)
            bubble.color = new Color(0, 0, 0, 0);

        switch (activeAction) // colour is placeholder for graphics
        {
            case Actions.DoCheckup:
                bubble.color = new Color(0, 0, 0, 255);
                break;
            case Actions.CheckTemperature:
                bubble.color = new Color(0, 255, 0, 255);
                break;
        }

    }

}

public enum ClientState
{
    Walking,                //action done
    WaitingToBePlaced,      //after reaching this state the first timer goes on
    WaitingForAction,       //after being in the right place the timer for action
    WaitingToPay,           //no timer, last state

}