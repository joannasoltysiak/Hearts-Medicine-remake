using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoom: MonoBehaviour
{
    static Vector2 place1 = new Vector2(-4, -3);
    static Vector2 place2 = new Vector2(-6, -3);
    static Vector2 place3 = new Vector2(-8, -3);

    public Client client;

    static List<int> clients = new List<int>();

    public void SpawnClient()
    {
        switch (clients.Count)
        {
            case 0:
                client.transform.position = place1;
                client.isInWaitingRoom = 0;
                Instantiate(client, client.transform); //Cannot instantiate objects with a parent which is persistent. New object will be created without a parent. SOME BUG???
                clients.Add(0);
                break;
            case 1:
                client.transform.position = place2;
                client.isInWaitingRoom = 1;
                Instantiate(client, client.transform);
                clients.Add(1);
                break;
            case 2:
                client.transform.position = place3;
                client.isInWaitingRoom = 2;
                Instantiate(client, client.transform);
                clients.Add(2);
                break;
            default:
                Debug.Log("You lost a client LOL");
                break;
        }
    }

    public static void DeleteClient(int client)
    {
        Debug.Log(clients.Remove(client));
        Debug.Log("DELETED " + clients.Count);
    }

}
