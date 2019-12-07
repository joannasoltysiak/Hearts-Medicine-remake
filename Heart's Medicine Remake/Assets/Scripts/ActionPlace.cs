using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlace : MonoBehaviour
{
    public PlaceType type;
    public Client client;

    //public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        client = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {

    }
}

public enum PlaceType
{
    Bed,            //place for Client to lay down -> bed actions
    WaitingSeats,   //place where Client wait to be picked
    Reception,      //where Client wait to pay
    Chair           //place for Client to sit -> chair actions
}
