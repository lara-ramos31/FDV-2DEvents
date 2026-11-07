using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Slider))]
public class HealthBar : MonoBehaviour
{
    public PlayerGameplay player;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
        player.onHealthChange += UpdateHealthbar;
    }

    void UpdateHealthbar(float health)
    {
        slider.value = health / PlayerGameplay.maxHealth;
    }
}
