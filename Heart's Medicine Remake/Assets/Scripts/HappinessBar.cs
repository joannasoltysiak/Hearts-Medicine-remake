using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessBar : MonoBehaviour
{
    float value;

    // Start is called before the first frame update
    void Start()
    {
        value = 1f;
    }

    public void MinusValue(float change)
    {
        value -= change;
    }

    public void AddValue(float change)
    {
        value -= change;
    }
}
