using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]

public class ShowHealth : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private float _currentHealth;
    private float _maxHealth;

    private void Awake() 
    {
        _slider = GetComponent<Slider>();
        _currentHealth = _player.GetCurrentHealth();
        _maxHealth = _player.GetMaxHealth();
        _slider.value = _currentHealth / _maxHealth;
    }

    public void ChangeHealthBar()
    {
        _currentHealth = _player.GetCurrentHealth();
        _maxHealth = _player.GetMaxHealth();
        _slider.value = _currentHealth / _maxHealth;
    }
}
