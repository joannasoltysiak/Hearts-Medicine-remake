using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    GameObject clickedObject;
    Vector2 clickedPlace;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            switch (hit.collider.tag)
            {
                case "Client":
                    clickedObject = hit.collider.gameObject;
                    break;
                case "ActionPlace":
                    break;
                case "Floor":
                    clickedPlace = hit.transform.position;
                    break;
                default:
                    break;
            }
        }
    }
}
