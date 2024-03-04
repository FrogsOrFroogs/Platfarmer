using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Slider healthSlider;

    public void alterMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value += health;
    }

    public void alterHealth(int health)
    {
        healthSlider.value = health;
    }
}
