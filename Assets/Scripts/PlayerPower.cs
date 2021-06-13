using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    public float maxResourceSeconds = 3;
    float powerResourceSeconds = 3;
    public float depleteRateSeconds = 1;
    public PowerBar powerBar;

    public Player playerController;

    bool powerOn = false;

    void Start()
    {
        powerResourceSeconds = maxResourceSeconds;
    }

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
        powerBar.SetBarValue(powerResourceSeconds / maxResourceSeconds);
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
