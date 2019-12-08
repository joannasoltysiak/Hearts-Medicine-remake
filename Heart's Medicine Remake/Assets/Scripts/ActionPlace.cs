﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlace : MonoBehaviour
{
    public PlaceType type;
    Client client;
    Actions[] possibleActions;

    //public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
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
        if(client != null && client.activeAction == Actions.None && client.state == ClientState.WaitingForAction)
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

    public bool IsTaken()
    {
        if (client == null)
            return false;
        else
            return true;
    }

    public void MakeEmpty()
    {
        client = null; //how to do it??
    }
}

public enum PlaceType
{
    Bed,            //place for Client to lay down -> bed actions
    WaitingSeats,   //place where Client wait to be picked
    Reception,      //where Client wait to pay
    Chair           //place for Client to sit -> chair actions
}

public enum Actions
{
    None,
    DoCheckup,
    CheckTemperature
}