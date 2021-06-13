using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator animator;
    public Player player;
    Transform playerTransform;
    public float speed = 150f;
    public float radius = 0.5f;

    public Rigidbody2D rb;

    Vector3 movementVect = Vector3.zero;

    Vector3 characterScale;
    float characterScaleX;

    LineRenderer linerend;
    public float lineWidth = 0.1f;

    Color white = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    float alpha = 0.3f;
    float visibility = 0.3f;

    void Start()
    {
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;

        playerTransform = player.transform;
        linerend = GetComponent<LineRenderer>();
        linerend.startWidth = Mathf.Max(0.1f, lineWidth);
        linerend.endWidth = Mathf.Max(0.1f, lineWidth);
    }

    void Update()
    {
        Debug.DrawRay(transform.position, playerTransform.position, Color.white);
        float dist = Vector3.Distance(transform.position, playerTransform.position);

        movementVect = Vector3.zero;

        if (dist < radius && player.isVisible)
        {
            visibility = Mathf.Min(1.0f, visibility * 1.03f);
            movementVect = transform.position - playerTransform.position;
            movementVect = Vector3.Normalize(movementVect);
        } else
        {
            visibility = Mathf.Max(alpha, visibility * 0.98f);
        }
        Color lineColor = new Color(1.0f, 1.0f, 1.0f, visibility);

        linerend.startColor = lineColor;
        linerend.endColor = lineColor;
        linerend.positionCount = 2;
        linerend.SetPosition(0, transform.position);
        linerend.SetPosition(1, playerTransform.position);
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
