﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlace : MonoBehaviour
{
    public PlaceType type;
    Client client;
    Actions[] possibleActions;
    GameObject placeForStanding;


    // Start is called before the first frame update
    void Start()
    {
        placeForStanding = new GameObject();
        placeForStanding.transform.position = transform.position;
        client = null;

        switch (type)
        {
            case PlaceType.Bed:
                possibleActions = new Actions[]{ Actions.DoCheckup, Actions.CheckTemperature };
                break;
            case PlaceType.Chair:
                possibleActions = new Actions[] { Actions.DoCheckup };
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(client != null && client.activeAction == Actions.None && client.state == ClientState.WaitingForAction && client.canBeChoosed)
        {
            int random = Random.Range(0, possibleActions.Length);
            client.activeAction = possibleActions[random];

            client.ChangeBubble(); //showing what client wants (need to implement)
        }
        
    }

    public void SetClient(Client client)
    {
        this.client = client;
    }

    public Client GetClient()
    {
        return client;
    }

    public bool IsTaken()
    {
        if (client == null)
            return false;
        else
            return true;
    }

    public void MakeEmpty()
    {
        client = null;
    }

    public Transform GetPosition(PositionType type) //sets position where client or player will stand after clicking this object
    {
        switch (type)
        {
            case PositionType.ForClient:
                placeForStanding.transform.position =  new Vector2(transform.position.x, transform.position.y - 0.1f - transform.localScale.y / 2);
                break;
            case PositionType.ForPlayer:
                placeForStanding.transform.position = new Vector2(transform.position.x + transform.localScale.x/2 , transform.position.y - 0.1f - transform.localScale.y / 2);
                break;
            case PositionType.Same:
                placeForStanding.transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f - transform.localScale.y/2);
                break;
            default:
                placeForStanding.transform.position = new Vector2(transform.position.x,transform.position.y);
                break;
        }
        return placeForStanding.transform;
    }
}

public enum PlaceType
{
    Bed,            //place for Client to lay down -> bed actions
    WaitingSeats,   //place where Client wait to be picked
    Reception,      //where Client wait to pay
    Chair,           //place for Client to sit -> chair actions
    WaitingRoom
}

public enum Actions
{
    None,
    DoCheckup,
    CheckTemperature
}

public enum PositionType
{
    ForClient, //specific position for client to go (eg. chair)
    ForPlayer, // specific position for player (eg. chair)
    Same //both go to the same place (eg. bed)
}