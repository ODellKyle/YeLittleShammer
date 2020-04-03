using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Character character;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth(character.hp);
    }

    void Update()
    {
        SetHealth(character.hp);
    }

    public void SetHealth(int health) 
    {
        slider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
