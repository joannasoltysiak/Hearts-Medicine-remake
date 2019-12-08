using System.Collections;
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
                possibleActions = new Actions[]{ Actions.CheckTemperature, Actions.CheckTemperature };
                break;
            case PlaceType.Chair:
                possibleActions = new Actions[] { Actions.DoCheckup };
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(client != null && client.activeAction == Actions.None)
        {
            int random = Random.Range(0, possibleActions.Length - 1);
            client.activeAction = possibleActions[random];

            client.ChangeBubble(); //showing what client wants (need to implement)
        }

        //checking if player comes and if they got everything needed for active action
    }

    public void Clicked()
    {

    }

    public void SetClient(Client client)
    {
        this.client = client;
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
    GetTermometr,
    DoCheckup,
    CheckTemperature
}