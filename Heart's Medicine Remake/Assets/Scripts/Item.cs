using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType item;

}

public enum ItemType
{
    None,
    Termometer
}