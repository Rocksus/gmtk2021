using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Player playerController;
    public float speed = 0f;

    Vector3 movementVect = new Vector3(0.0f, 0.0f, 0.0f);

    void Update()
    {
        movementVect = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
    }

    void FixedUpdate()
    {
        playerController.Move(movementVect * speed * Time.deltaTime);
    }
}
