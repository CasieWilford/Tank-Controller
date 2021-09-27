using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] FlashImage flashImage = null;
    [SerializeField] int _maxHealth = 5;
    int _currentHealth;

    public HealthBar healthBar;

    public ParticleSystem deathParticle;
    private CameraShake shake;

    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    // Level starts, current health is set to max amount.
    private void Start()
    {
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth(_maxHealth);
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
        healthBar.SetHealth(_currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        shake.CamShake();
        flashImage.StartFlash();

        _currentHealth -= amount;
        Debug.Log("Player's health: " + _currentHealth);
        healthBar.SetHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Instantiate(deathParticle, transform.position, transform.rotation);
        gameObject.SetActive(false);
        // Play particles and sounds.
    }

    public void IncreaseTreasure()
    {
        Treasure.currentTreasure += 1;
    }

    private void Update()
    {
        
    }
}
