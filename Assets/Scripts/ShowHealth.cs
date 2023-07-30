using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]

public class ShowHealth : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float _speed;

    private Coroutine _changeHealth;
    private Slider slider;
    private float _currentHealth;
    private float _maxHealth;
    private float _targetPosition;

    private void Start() =>
        slider = GetComponent<Slider>();

    public void ChangeHealthBar()
    {
        _currentHealth = player.GetCurrentHealth();
        _maxHealth = player.GetMaxHealth();
        _targetPosition = _currentHealth/ _maxHealth;

        if (_changeHealth != null)
            StopCoroutine(_changeHealth);

        _changeHealth = StartCoroutine(ShowHealthBar());
    }

    private IEnumerator ShowHealthBar()
    {
        while (slider.value != _targetPosition)
        {
            slider.value = Mathf.MoveTowards(slider.value, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
