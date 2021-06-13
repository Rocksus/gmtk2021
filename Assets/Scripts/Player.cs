using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 characterScale;
    float characterScaleX;

    public bool isVisible;
    public float minAlpha = 0.4f;
    float visibility = 1.0f;

    public Rigidbody2D rb;
    SpriteRenderer spriteRender;

    void Start()
    {
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
        spriteRender = GetComponentInChildren<SpriteRenderer>();
    }

    public void Move(Vector3 moveVect)
    {
        if(!isVisible)
        {
            moveVect = moveVect * 1.5f;
        }
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

    public void SetVisibility(bool visible)
    {
        isVisible = visible;
        if (visible)
        {
            visibility = Mathf.Min(1.0f, visibility * 1.1f);
            spriteRender.color = new Color(1.0f, 1.0f, 1.0f, visibility);
        } else
        {
            visibility = Mathf.Max(minAlpha, visibility * 0.9f);
            spriteRender.color = new Color(1.0f, 1.0f, 1.0f, visibility);
        }
    }
}
