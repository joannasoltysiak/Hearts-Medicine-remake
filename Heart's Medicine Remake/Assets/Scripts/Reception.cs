using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reception : MonoBehaviour
{
    List<Client> clients;   //this will retain data about customers standing in line

    void Start()
    {
        clients = new List<Client>();
    }

    public void AddNewClient(Client client)
    {
        clients.Add(client);
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
