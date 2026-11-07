using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    public Transform objective;
    public PlayerGameplay player;

    void Start()
    {
        if (objective == null)
        {
            Debug.LogError("TeleportObject: no objective!");
        }
        if (player == null)
        {
            Debug.LogError("TeleportObject: no player!");
            return;
        }
        player.onKeyCollected += TeleportToObjective;
    }

    void TeleportToObjective()
    {
        transform.position = objective.position;
    }
}
