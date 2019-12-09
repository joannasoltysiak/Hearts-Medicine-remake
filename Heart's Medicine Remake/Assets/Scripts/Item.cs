using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType item;

    public Vector2 GetPosition(PositionType type)
    {
        switch (type)
        {
            case PositionType.ForPlayer:
                return new Vector2(transform.position.x, transform.position.y);
            default:
                return new Vector2(transform.position.x, transform.position.y);
        }
    }
}

public enum ItemType
{
    None,
    Termometer
}