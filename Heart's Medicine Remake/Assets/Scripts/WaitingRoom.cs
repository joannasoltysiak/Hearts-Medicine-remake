using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoom: MonoBehaviour
{
    static Vector2[] places = { new Vector2(-4, -3), new Vector2(-6, -3), new Vector2(-8, -3) };

    public Client client;
   
    static int numberOfClients = 0;
    static bool[] emptyPlaces = {true, true, true};

    public void SpawnClient() // spawning clients on the proper position 
    {
        if (numberOfClients < 3)
        {
            Timer.clientsOnMap++;
            NewClient();
        }
        else
        {
            Debug.Log("You lost a client LOL");
        } 
    }

    public static void DeleteClient(int client)
    {
        emptyPlaces[client] = true;         //after client leaves the place - it's empty again
        numberOfClients--;
    }

    public void NewClient()
    {
        Client newClient = Instantiate(client, new Vector3(0, 0, 0), Quaternion.identity);          //creating new client
        int firstEmpty = 0;                 //position of first empty place for client to appear

        for (int i = 2; i >= 0; i--)
        {
            if (emptyPlaces[i])             //if place is empty
            {
                firstEmpty = i;             //take this place
            }
        }
        emptyPlaces[firstEmpty] = false;    //client takes this place 

        newClient.transform.position = places[firstEmpty];      //changing his position to the empty seat
        newClient.isInWaitingRoom = firstEmpty;
        numberOfClients++;

    }

}
