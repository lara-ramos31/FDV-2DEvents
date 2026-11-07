using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RabidPet : MonoBehaviour
{
    public float distanceThreshold = 2.5f;
    public float scorePenaltyPerSecond = 100f;
    public GameObject player;
    private PlayerGameplay player_gameplay;
    private SpriteRenderer renderer;

    void Start()
    {
        if (player == null) {
            Debug.LogError("Pet: no player!");
        }
        player_gameplay = player.GetComponent<PlayerGameplay>();
        if (player_gameplay == null) {
            Debug.LogError("Pet: no score!");
        }
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= distanceThreshold) {
            player_gameplay.AddScore(-scorePenaltyPerSecond * Time.deltaTime);
            renderer.color = Color.red;
        } else {
            renderer.color = Color.white;
        }
    }
}
