using UnityEngine;

[RequireComponent (typeof(SpriteRenderer), typeof(Animator))]
public class RotationMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float angularSpeed = 135.0f;
    public float minWalkingDistance = 0.001f;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Vector2 restingPosition;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        restingPosition = transform.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(0, 0, -angularSpeed * horizontalInput * Time.deltaTime);
        movement.Set(speed * Time.deltaTime * verticalInput, 0);
        transform.Translate(movement, Space.Self);
        if (verticalInput > 0) { // facing right
            spriteRenderer.flipX = false;
        } else if (verticalInput < 0) { // facing left
            spriteRenderer.flipX = true;
        }
        float distanceThisFrame = Vector2.Distance(restingPosition, transform.position);
        if (distanceThisFrame >= minWalkingDistance) {
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }
        restingPosition = transform.position;
    }
}
