using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reception : MonoBehaviour
{
    static List<Client> clients;   //this will retain data about customers standing in line
    static Vector3 nextPosition;
    public Vector3 basePosition;

    public void Start()
    {
        clients = new List<Client>();
    }

    public static void AddNewClient(Client client)  //addding new client to list clients
    {
        if (client != null)
            clients.Add(client);
    }

    public static Vector3 GetNextPosition()
    {
        Vector3 pos = nextPosition;
        nextPosition.x -= 1;

        return pos;
    }

    public void GetPoints()
    {
        foreach (Client c in clients)
        {
            GameState.points += 10;
        }

        clients.Clear();
    }

}
