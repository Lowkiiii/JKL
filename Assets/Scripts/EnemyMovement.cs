using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the enemy moves
    public float moveDistance = 5f; // The distance the enemy moves from side to side

    private bool movingRight = false; // Set to false to make the enemy start moving left
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get the camera bounds
        float cameraWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
        float cameraLeftEdge = -cameraWidth / 2f;
        float cameraRightEdge = cameraWidth / 2f;

        // If the enemy is moving right and has reached the right edge, change direction and flip the sprite
        if (transform.position.x >= cameraRightEdge && movingRight)
        {
            movingRight = false;
            spriteRenderer.flipX = false; // flip the sprite to face left
        }
        // If the enemy is moving left and has reached the left edge, change direction and flip the sprite
        else if (transform.position.x <= cameraLeftEdge && !movingRight)
        {
            movingRight = true;
            spriteRenderer.flipX = true; // flip the sprite to face right
        }

        // Move the enemy in the appropriate direction
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

        // Check if the enemy has gone too far left and move it to the right
        if (transform.position.x <= cameraLeftEdge - moveDistance && !movingRight)
        {
            transform.position = new Vector2(cameraRightEdge + moveDistance, transform.position.y);
        }
        // Check if the enemy has gone too far right and move it to the left
        else if (transform.position.x >= cameraRightEdge + moveDistance && movingRight)
        {
            transform.position = new Vector2(cameraLeftEdge - moveDistance, transform.position.y);
        }
    }
}