using UnityEngine;

public class PlayerGameplay : MonoBehaviour
{
    // Variables
    public const float maxHealth = 100;
    private float health = maxHealth;
    private float score = 0;

    // Events
    public delegate void FloatChanged(float val);
    public FloatChanged onHealthChange; // val is new health
    public FloatChanged onScoreChange; // val is new score

    void Start()
    {
        onHealthChange?.Invoke(health);
        onScoreChange?.Invoke(score);
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health < 0) { health = 0; }
        onHealthChange?.Invoke(health);
    }

    public void AddScore(float delta)
    {
        score += delta;
        if (score < 0) { score = 0; }
        onScoreChange?.Invoke(score);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.layer)
        {
            case 8: // harmful, don't forget!
                ApplyDamage(10);
                break;    
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.layer)
        {
            case 10: // collectable
                AddScore(50);
                Destroy(other.gameObject);
                break;
        }
    }
}