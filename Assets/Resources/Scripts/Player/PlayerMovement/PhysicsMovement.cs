using UnityEngine;

[RequireComponent(
    typeof(SpriteRenderer), 
    typeof(Animator),
    typeof(Rigidbody2D)
)]
public class PhysicsMovement : MonoBehaviour
{
    public const float baseHForce = 9f;
    public const float stealthHForce = 6.7f;
    public bool isStealthy = false;
    public float hForce = baseHForce;
    public float vForce = 15.0f;
    public float minWalkingDistance = 0.001f;
    public float jumpSeconds = 1.3f;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 restingPosition;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        restingPosition = transform.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        movement.Set(horizontalInput, verticalInput);
        float distanceThisFrame = Vector2.Distance(restingPosition, transform.position);
        if (distanceThisFrame >= minWalkingDistance) {
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }
        restingPosition = transform.position;
    }

    void FixedUpdate()
    {
        Vector2 forceVec = new(hForce * movement.x, vForce * movement.y);
        rb.AddForce(Time.fixedDeltaTime * forceVec, ForceMode2D.Impulse);
        if (movement.x > 0) { // facing right
            spriteRenderer.flipX = false;
        } else if (movement.x < 0) { // facing left
            spriteRenderer.flipX = true;
        }
    }

    public void ToggleStealth()
    {
        isStealthy = !isStealthy;
        if (isStealthy) {
            hForce = stealthHForce;
        } else {
            hForce = baseHForce;
        }
    }
}
