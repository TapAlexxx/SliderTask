using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _heroMaxHP;
    [SerializeField] private float _speed;
    [SerializeField] private Slider _hpBar;
    
    private float _currentHeroHP;
    private float _targetHeroHP;

    private void Awake()
    {
        _currentHeroHP = _heroMaxHP;
        _targetHeroHP = _heroMaxHP;
        _hpBar.value = _currentHeroHP / _heroMaxHP;
    }
    private void Update()
    {
        if (_targetHeroHP >= _currentHeroHP)
        {
            _currentHeroHP += Time.deltaTime * _speed;
        }
        else if (_targetHeroHP <= _currentHeroHP)
        {
            _currentHeroHP -= Time.deltaTime * _speed;
        }
        _hpBar.value = _currentHeroHP / _heroMaxHP;
    }

    public void TakeDamage(float damage)
    {
        _targetHeroHP -= damage;
        if (_targetHeroHP < 0)
        {
            _targetHeroHP = 0;
        }
    }

    public void AddHealthPoints(float points)
    {
        _targetHeroHP += points;
        if (_targetHeroHP > _heroMaxHP)
        {
            _targetHeroHP = _heroMaxHP;
        }
    }
}
