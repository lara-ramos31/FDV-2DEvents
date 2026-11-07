using TMPro;
using UnityEngine;

[RequireComponent (typeof (TextMeshProUGUI))]
public class ScoreText : MonoBehaviour
{
    public PlayerGameplay player;
    private TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        player.onScoreChange += UpdateScoreText;
    }

    void UpdateScoreText(float score)
    {
        text.text = "Points: " + ((int)score).ToString();
    }
}
