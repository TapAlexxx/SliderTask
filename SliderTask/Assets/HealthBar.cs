using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Hero _hero;

    public void UpdateHpBar()
    {
        _hpBar.value = _hero.NormalizedHeroHP;
    }
}
