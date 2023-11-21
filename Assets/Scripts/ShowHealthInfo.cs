using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class ShowHealthInfo : MonoBehaviour
{
    [SerializeField] Player _player;

    private TextMeshProUGUI _text;
    private float _maxHealth;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _maxHealth = _player.GetMaxHealth();
        _text.text = _player.GetCurrentHealth() + "/" + _maxHealth;
    }


    public void ShowHealth() =>
        _text.text =  _player.GetCurrentHealth() + "/" + _maxHealth;
}
