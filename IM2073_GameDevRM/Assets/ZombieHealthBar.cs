using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;
    // Start is called before the first frame update

    public void SetHealthBar(int health)
    {
        float healthPercent = health;
        _healthbarSprite.fillAmount = healthPercent/100;
    }
}
