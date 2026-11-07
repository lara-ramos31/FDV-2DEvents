using UnityEngine;

[RequireComponent (typeof(SpriteRenderer), typeof(Animator))]
public class NoRotationMovement : MonoBehaviour
{
    public float speed = 1.0f;
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
        movement.Set(horizontalInput, verticalInput);
        transform.Translate(speed * Time.deltaTime * movement);
        if (horizontalInput > 0) { // facing right
            spriteRenderer.flipX = false;
        } else if (horizontalInput < 0) { // facing left
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
