using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedPlace : MonoBehaviour
{
    private Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);


            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Input.mousePosition;

            Debug.Log("hit : " + transform.position);
            Debug.Log("hit : " + Input.mousePosition);
        }
    }
}
