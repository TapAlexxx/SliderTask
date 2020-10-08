using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _heroMaxHP;
    [SerializeField] private float _speed;
    [SerializeField] private UnityEvent _hpChanged;

    public float NormalizedHeroHP { get; private set; }
    
    private float _currentHeroHP;
    private float _targetHeroHP;

    private void Awake()
    {
        _currentHeroHP = _heroMaxHP;
        _targetHeroHP = _heroMaxHP;
        NormalizedHeroHP = _currentHeroHP / _heroMaxHP;
        _hpChanged.Invoke();
    }
    private void Update()
    {
        if (_currentHeroHP != _targetHeroHP)
        {
            _currentHeroHP = Mathf.Lerp(_currentHeroHP, _targetHeroHP, _speed * Time.deltaTime);
            NormalizedHeroHP = _currentHeroHP / _heroMaxHP;
            _hpChanged.Invoke();
        }
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
