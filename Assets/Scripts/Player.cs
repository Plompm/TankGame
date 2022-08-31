using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{

    [SerializeField] ParticleSystem _deathParticle;
    [SerializeField] AudioClip _deathClip;
    [SerializeField] Text _treasureAt;
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;
    int _currentTreasure;

    public bool _invicible = false;

    TankController _tankcontroller;

    private void Awake()
    {
        _tankcontroller = GetComponent<TankController>();
    }

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        if (_invicible == false)
        {
            _currentHealth -= amount;
            Debug.Log("Player's health: " + _currentHealth);
            if (_currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        if (_invicible == false)
        {
            Feedback();
            gameObject.SetActive(false);
        }
    }

    public void IncreaseTreasure(int amount)
    {
        _currentTreasure += amount;
        _treasureAt.text = "Treasure amount: " + amount;
    }

    private void Feedback()
    {
        if (_deathParticle != null)
        {
            _deathParticle = Instantiate(_deathParticle, transform.position, Quaternion.identity);
        }

        if (_deathClip != null)
        {
            AudioHelper.PlayClip2D(_deathClip, 1f);
        }
    }
}
