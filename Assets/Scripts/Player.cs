using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private UnityEvent _changeHealth;

    public void TekeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;

        _changeHealth?.Invoke();
    }

    public void Heal(int heal)
    {
        _currentHealth += heal;

        if (_currentHealth > _maxHealth) 
            _currentHealth = _maxHealth;

        _changeHealth?.Invoke();
    }

    public int GetCurrentHealth() =>
        _currentHealth;

    public int GetMaxHealth() =>
        _maxHealth;
}
