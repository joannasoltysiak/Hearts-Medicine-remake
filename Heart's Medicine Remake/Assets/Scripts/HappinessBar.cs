using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessBar : MonoBehaviour
{
    float value;
    Vector2 scale;

    // Start is called before the first frame update
    void Start()
    {
        value = 1f;
        scale = new Vector2(1f, 0.3f);
    }

    public void MinusValue(float change)
    {
        if (value > 0)
        {
            value -= change;
            scale.x = value;
            transform.localScale = scale;
        }
    }

    public void AddValue(float change)
    {
        value += change;
        scale.x = value;
        transform.localScale = scale;
    }

    public float GetValue()
    {
        return value;
    }

    public void SetValue(float change)
    {
        value = change;
        scale.x = value;
        transform.localScale = scale;
    }

}
