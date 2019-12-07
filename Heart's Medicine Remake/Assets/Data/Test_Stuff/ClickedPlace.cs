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
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
