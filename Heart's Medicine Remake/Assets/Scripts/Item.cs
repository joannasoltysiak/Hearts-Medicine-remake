using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType item;
    GameObject placeForStanding;

    void Start()
    {
        placeForStanding = new GameObject();
        placeForStanding.transform.position = transform.position;
    }

        public Transform GetPosition(PositionType type)//sets position where player will stand after clicking this object
    {
        switch (type)
        {
            case PositionType.Same:
                placeForStanding.transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f - transform.localScale.y / 2);
                break;
            default:
                placeForStanding.transform.position = new Vector2(transform.position.x, transform.position.y);
                break;
        }
        return placeForStanding.transform;
    }
}

public enum ItemType
{
    None,
    Termometer
}