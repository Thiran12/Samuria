using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rb2;
    private float dirX = 0f;
    [SerializeField] private float playerMoveSpeed = 5f;
    [SerializeField] private float playerJumpHeight = 15f;
    private void Start ()
    {
        rb2 = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb2.velocity = new Vector2(dirX * playerMoveSpeed, rb2.velocity.y);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2.velocity.y) < 0.001f)
        {
            rb2.AddForce(new Vector2(0, playerJumpHeight), ForceMode2D.Impulse);
        }
        if (dirX > 0f)
        {
            sprite.flipX = false;

        }
        else if (dirX <0)
        {
            sprite.flipX = true;
        }
    }
}