using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoom
{
    static Vector2 place1 = new Vector2(-4, -3);
    static Vector2 place2 = new Vector2(-6, -3);
    static Vector2 place3 = new Vector2(-8, -3);

    public static GameObject client;

    static List<GameObject> clients;

    public static void SpawnClient()
    {
        switch (clients.Count)
        {
            case 0:
                client.transform.position = place1;
                Object.Instantiate(client, client.transform);
                clients.Add(client);
                break;
            case 1:
                client.transform.position = place2;
                Object.Instantiate(client, client.transform);
                clients.Add(client);
                break;
            case 2:
                client.transform.position = place3;
                Object.Instantiate(client, client.transform);
                clients.Add(client);
                break;
            default:
                Debug.Log("You lost a client LOL");
                break;
        }
    }

    public void DeleteClient(GameObject client)
    {
        clients.Remove(client);
    }

}
