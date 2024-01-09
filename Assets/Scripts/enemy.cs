using UnityEngine;

public class RandomMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isMoving = false;
    private float randomMoveTimer = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!isMoving)
        {
            // Start a new random movement direction
            randomMoveTimer = Random.Range(1f, 3f);
            isMoving = true;
        }

        // Move the object in the chosen direction
        Move();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // Decrease the timer
            randomMoveTimer -= Time.fixedDeltaTime;

            // If the timer reaches zero, stop moving
            if (randomMoveTimer <= 0f)
            {
                isMoving = false;
            }
        }
    }

    void Move()
    {
        // Randomly choose a direction
        int direction = Random.Range(0, 4); // 0: up, 1: down, 2: left, 3: right

        switch (direction)
        {
            case 0:
                // Move up
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
                break;
            case 1:
                // Move down
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
                break;
            case 2:
                // Move left
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                break;
            case 3:
                // Move right
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If there's a collision, stop moving and change direction
        isMoving = false;

        // Reverse the direction
        int newDirection = Random.Range(0, 4); // 0: up, 1: down, 2: left, 3: right
        MoveInDirection(newDirection);
    }

    void MoveInDirection(int direction)
    {
        switch (direction)
        {
            case 0:
                // Move up
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
                break;
            case 1:
                // Move down
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
                break;
            case 2:
                // Move left
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                break;
            case 3:
                // Move right
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                break;
        }

        // Set isMoving to true again
        isMoving = true;
    }
}
