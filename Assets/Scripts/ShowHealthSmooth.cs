using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]

public class ShowHealthSmooth : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    private Coroutine _changeHealth;
    private Slider _slider;
    private float _currentHealth;
    private float _maxHealth;
    private float _targetPosition;

    private void Start()
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
        _targetPosition = _currentHealth / _maxHealth;

        if (_changeHealth != null)
            StopCoroutine(_changeHealth);

        _changeHealth = StartCoroutine(ShowHealthBar());
    }

    private IEnumerator ShowHealthBar()
    {
        while (_slider.value != _targetPosition)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
    }
}