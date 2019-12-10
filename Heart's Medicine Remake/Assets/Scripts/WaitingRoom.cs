using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoom: MonoBehaviour
{
    static Vector2 place1 = new Vector2(-4, -3);
    static Vector2 place2 = new Vector2(-6, -3);
    static Vector2 place3 = new Vector2(-8, -3);

    static Vector2[] places = { place1, place2, place3 };

    public Client client;
    
    static int numberOfClients = 0;

    static bool[] emptyPlaces = {true, true, true};

    public void SpawnClient() // spawning clients on the proper position 
    {
        if (numberOfClients < 3)
        {
            NewClient();
        }
        else
        {
            Debug.Log("You lost a client LOL");
        } 
    }

    public static void DeleteClient(int client)
    {
        emptyPlaces[client] = true;
        numberOfClients--;
    }

    public void NewClient()
    {
        Client newClient = Instantiate(client, new Vector3(0, 0, 0), Quaternion.identity);
        int firstEmpty = 0;

        for (int i = 2; i >= 0; i--)
        {
            if (emptyPlaces[i])
            {
                firstEmpty = i;
            }
        }
        emptyPlaces[firstEmpty] = false;

        newClient.transform.position = places[firstEmpty];
        newClient.isInWaitingRoom = firstEmpty;
        numberOfClients++;

    }

}
