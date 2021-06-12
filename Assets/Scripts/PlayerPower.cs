using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    public float powerResourceSeconds = 3;
    public float depleteRateSeconds = 1;

    public Player playerController;

    bool powerOn = false;

    void Update()
    {
          powerOn = Input.GetKey("space");
    }

    void FixedUpdate()
    {
        if (powerOn && powerResourceSeconds>0)
        {
            PowerOn(depleteRateSeconds * Time.deltaTime);
        } else
        {
            PowerOff();
        }
    }

    void PowerOn(float amount)
    {
        powerResourceSeconds = Mathf.Max(0f, powerResourceSeconds - amount);
        if (powerResourceSeconds > 0)
        {
            playerController.SetVisibility(false);
        }
    }

    void PowerOff()
    {
        playerController.SetVisibility(true);
    }
}
