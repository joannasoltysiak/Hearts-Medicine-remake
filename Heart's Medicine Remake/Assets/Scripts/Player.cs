using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Player : MonoBehaviour
{
    Item[] itemList; 
    Vector2 currentPosition;
    AIDestinationSetter pathfindingTarget;
    

    // Start is called before the first frame update
    void Start()
    {
        itemList = new Item[3];
        currentPosition = transform.position;
        pathfindingTarget = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTargetPosition(Transform position)
    {
        pathfindingTarget.target = position;
    }
}
