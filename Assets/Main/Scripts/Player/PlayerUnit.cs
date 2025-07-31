using System;
using Main.Scripts.Player;
using UnityEngine;

public class PlayerUnit : MonoBehaviour, IDamageable
{

    [SerializeField] private float _maxHealth = 100f;
    
    [SerializeField] private float _currentHealth;
    public float CurrentHealth => _currentHealth;

    private Action<float> _onDamage;
    private Action _onDeath;

    public void Initialize(Action<float> onDamage, Action onDeath)
    {
        _onDamage = onDamage;
        _onDeath = onDeath;
        _currentHealth = _maxHealth;
    }

    public void GetDamage(float damage)
    {
        _currentHealth -= damage;
        OnDamage();
        if (_currentHealth <= 0)
        {
            OnDeath();
        }
    }

    private void OnDamage()
    {
     _onDamage?.Invoke(_currentHealth);   
    }

    private void OnDeath()
    {
        _onDeath?.Invoke();
    }
}
