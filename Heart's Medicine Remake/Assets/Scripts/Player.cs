using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Item[] itemList;
    Vector2 currentPosition;
    Vector2 targetPosition;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        itemList = new Item[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
