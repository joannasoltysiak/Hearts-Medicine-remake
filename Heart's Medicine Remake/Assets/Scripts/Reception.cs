using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reception : MonoBehaviour
{
    public static List<Client> clients;   //this will retain data about customers standing in line
    static Vector2 nextPosition;
    static Vector2 basePosition;
    public static Transform positionTransform;
    public static Transform playerPosition;
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
        playerPosition = GetNewTransform();
        playerPosition.transform.position = new Vector2(5, -2);
    }

    public static void AddNewClient(Client client)  //addding new client to list clients
    {
        if (client != null)
            clients.Add(client);

    }

    public static Transform GetNextPosition()
    { 
        nextPosition.x -= 1;
        positionTransform.transform.position = nextPosition;

        checkoutPositions.Add(positionTransform);

        Transform nextInLine = positionTransform;

        positionTransform = GetNewTransform();

        return nextInLine;
    }

    public static void GetPoints()
    {

        if (clients.Count > 0)
        {
            foreach (Client c in clients)
            {

                GameState.points += (int)(c.happinessBar.GetValue() * 100);      //we got as many points as client's happiness value * 100
                Timer.clientsOnMap--;

                Destroy(c.gameObject);          //for now - it destroys the client object
            }

            clients.Clear();
            nextPosition = basePosition;
        }
    }

    public static Transform GetNewTransform()
    {
        GameObject emptyGO = new GameObject();
        Transform newTransform = emptyGO.transform;
        newTransform.transform.position = Vector3.zero;

        return newTransform;
    }

}
