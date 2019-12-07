using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public ClientState state;

    // Start is called before the first frame update
    void Start()
    {
        state = ClientState.Walking;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum ClientState
{
    Walking,                //action done
    WaitingToBePlaced,      //after reaching this state the first timer goes on
    WaitingForAction,       //after being in the right place the timer for action
    WaitingToPay,           //no timer, last state

}
