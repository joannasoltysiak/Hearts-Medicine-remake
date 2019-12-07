using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighting : MonoBehaviour
{
    private Renderer rend;
    private Color colorNow;

    [SerializeField]
    private Color colorToTurnTo = Color.white;



    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        colorNow = rend.material.color;
    }

    void OnMouseOver()
    {
        rend.material.color = colorToTurnTo;
    }

    void OnMouseExit()
    {
        rend.material.color = colorNow;
    }
}
