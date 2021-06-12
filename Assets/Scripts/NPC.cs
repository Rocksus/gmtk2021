using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator animator;
    public Player player;
    Transform playerTransform;
    public float speed = 0.1f;
    public float radius = 0.5f;

    public Rigidbody2D rb;

    Vector3 movementVect = Vector3.zero;

    Vector3 characterScale;
    float characterScaleX;

    LineRenderer linerend;
    public float lineWidth = 0.2f;

    void Start()
    {
        playerTransform = player.transform;
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;

        linerend = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, playerTransform.position, Color.white);
        float dist = Vector3.Distance(transform.position, playerTransform.position);

        movementVect = Vector3.zero;
        linerend.positionCount = 0;
        if (dist < radius && player.isVisible)
        {
            float magnitude = (radius - dist) / radius;
            linerend.positionCount = 2;
            linerend.startWidth = lineWidth * magnitude;
            linerend.endWidth = lineWidth * magnitude;
            linerend.SetPosition(0, transform.position);
            linerend.SetPosition(1, playerTransform.position);
            movementVect = transform.position - playerTransform.position;
            movementVect = Vector3.Normalize(movementVect);
        }
    }

    void FixedUpdate()
    {
        Move(movementVect * speed * Time.deltaTime);
    }

    void Move(Vector3 moveVect)
    {
        animator.SetFloat("horizontalspeed", Mathf.Abs(moveVect.x));
        animator.SetFloat("verticalspeed", Mathf.Abs(moveVect.y));
        rb.velocity = new Vector2(moveVect.x, moveVect.y);
        if (moveVect.x > 0)
        {
            characterScale.x = characterScaleX;
        }
        else if (moveVect.x < 0)
        {
            characterScale.x = -characterScaleX;
        }
        transform.localScale = characterScale;
    }
}
