using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
    Transform bar;
    void Start()
    {
        bar = transform.Find("Bar");
    }

    public void SetBarValue(float val)
    {
        bar.localScale = new Vector3(val, 1f);
    }
}
