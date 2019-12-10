using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reception : MonoBehaviour
{
    public static List<Client> clients;   //this will retain data about customers standing in line
    static Vector2 nextPosition;
    static Vector2 basePosition;
    public static Transform positionTransform;
    public static ActionPlace actionPlace;

    public static List<Transform> checkoutPositions;

    public void Start()
    {
        basePosition = new Vector2(8, -4.5f);
        clients = new List<Client>();
        nextPosition = basePosition;
        actionPlace = gameObject.GetComponent<ActionPlace>();

        checkoutPositions = new List<Transform>();

        positionTransform = GetNewTransform();
    }

    public static void AddNewClient(Client client)  //addding new client to list clients
    {
        if (client != null)
            clients.Add(client);

    }

    public static Transform GetNextPosition()
    {
        Vector3 pos = nextPosition;
        nextPosition.x -= 1;
        positionTransform.transform.position = nextPosition;

        checkoutPositions.Add(positionTransform);

        Transform nextInLine = positionTransform;

        positionTransform = GetNewTransform();

        return nextInLine;
    }

    public void GetPoints()
    {
        foreach (Client c in clients)
        {
            GameState.points += (int)(c.happinessBar.GetValue()*10);
        }

        clients.Clear();
        nextPosition = basePosition;
    }

    public static Transform GetNewTransform()
    {
        GameObject emptyGO = new GameObject();
        Transform newTransform = emptyGO.transform;
        newTransform.transform.position = Vector3.zero;

        return newTransform;
    }

}
