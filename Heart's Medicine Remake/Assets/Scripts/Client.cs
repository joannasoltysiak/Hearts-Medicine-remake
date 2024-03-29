﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Client : MonoBehaviour
{
    public ClientState state;

    Vector2 currentPosition;
    Vector3 targetPosition;
    public ActionPlace targetPlace;
    public SpriteRenderer bubble;

    public Actions activeAction;
    int numberOfActions;
    public bool canBeChoosed;
    public int isInWaitingRoom;

    public PlaceType wantedPlace;
    AIDestinationSetter pathfindingTarget;

    public HappinessBar happinessBar;
    public Animator animator;

    float waitingTime;

    Transform body;
    Vector3 bodyPos;

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

        numberOfActions = Random.Range(1, 2);
        happinessBar.MinusValue(numberOfActions * 0.1f);
        canBeChoosed = true;

        waitingTime = 0;

        body = this.gameObject.transform.GetChild(0);
        bodyPos = body.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingTime > 3) //waits for 5 seconds without substracting happiness
        {
            happinessBar.MinusValue(0.001f);
        }
        
        if ((Mathf.Abs(targetPosition.x - transform.position.x) < 0.2f  && Mathf.Abs(targetPosition.y - transform.position.y) < 0.2f ) 
            && state == ClientState.Walking)
        {
            waitingTime = 0;
            if(wantedPlace != PlaceType.Reception) //only after action 
                AddHappiness(0.2f);
            animator.SetBool("walking", false);
            if (wantedPlace == PlaceType.Bed)
                Rotate(90);

            state = ClientState.WaitingForAction;
            pathfindingTarget.target = transform;
            targetPosition = Vector3.zero;

            //transform.parent = targetPlace.transform;
        }

        if (state == ClientState.WaitingForAction && wantedPlace == PlaceType.Reception)
        {
            //first he walks towards next place in line before getting added to list of clients standing in front of Reception/Checkout

            Reception.AddNewClient(this);
            animator.SetBool("walking", false);

            state = ClientState.WaitingToPay;
            ChangeBubble();
        }

        if(state != ClientState.WaitingToPay)
        {
            waitingTime += Time.deltaTime;
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
            targetPlace.MakeEmpty();
            if (targetPlace.type == PlaceType.Bed)
                Rotate(0);
            SetTargetPosition(Reception.GetNextPosition(), Reception.actionPlace);

            return false;
        }
        return true;
    }

    public void Rotate(int degrees)
    {
        if(degrees==0)
            body.transform.localPosition = bodyPos;
        else
            body.transform.position = transform.position + new Vector3(-0.8f, 1.7f, 0f);
        
        body.transform.rotation = Quaternion.Euler(Vector3.forward * degrees);
    }

        public void SetTargetPosition(Transform position, ActionPlace targetPlace)
    {
        if (isInWaitingRoom >= 0)
        {
            WaitingRoom.DeleteClient(isInWaitingRoom);
            isInWaitingRoom = -1;
        }
        animator.SetBool("walking", true);

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
                bubble.color = new Color32(155,173, 183, 255);
                break;
            case PlaceType.Chair:
                bubble.color = new Color32(89, 86, 82, 255);
                break;
        }

        switch (activeAction) // colour is placeholder for graphics
        {
            case Actions.DoCheckup:
                bubble.color = new Color32(217, 87, 99, 255);
                break;
            case Actions.CheckTemperature:
                bubble.color = new Color32(224, 184, 146, 255);
                break;
        }

        if (state == ClientState.Walking)
            bubble.color = new Color(0, 0, 0, 0);
    }
    
    public void AddHappiness(float value)
    {
        if (happinessBar.GetValue() + value < 1)
            happinessBar.AddValue(value);
        else
            happinessBar.SetValue(1);
    }

    public void ResetWaitingTime()
    {
        waitingTime = 0;
    }
}

public enum ClientState
{
    Walking,                //action done
    WaitingToBePlaced,      //after reaching this state the first timer goes on
    WaitingForAction,       //after being in the right place the timer for action
    WaitingToPay,           //no timer, last state

}