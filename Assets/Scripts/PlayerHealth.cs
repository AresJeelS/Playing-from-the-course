using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Animator _animator;
    [SerializeField] private float totalhealth = 100f;

    private float _health;
    private void Start()
    {
        _health = totalhealth;
        InitHealth();
    }

    public void InitHealth()
    {
        healthSlider.value = _health / totalhealth;
    }
    public void ReduceHealth(float damage)
    {
        _health -= damage;
        hitSound.Play();
        InitHealth();
        _animator.SetTrigger("takeDamage");
        if (_health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        gameObject.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
}
