using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;        // Geschwindigkeit f�r Gegner
    public int maxHealth = 100;         // Max Gesundheit Gegner
    public int currentHealth;           // Aktuelle Gesundheit Gegner
    public GameObject itemPrefab;       // Prefab vom DropItem (Gegnerdrop)
    public float dropChance = 0.8f;     // Wahrscheinlichkeit f�r Itemdrop

    private Animator anim;              // Animator Gegners

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Bewegung alter
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.Play("Damage", 0, 0f);

        //Ist Gegner tot??
        if (currentHealth <= 0)
        {
            Die();
        }
    }

 
    void Die()
    {
        // Zuf�llige Chance f�r Itemdrop
        if (Random.value < dropChance)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }

        //vergebe Punkte - Referenz auf ScoreManager Skript
        ScoreManager.instance.AddScore(10);

        //Gegner Sprite Bums zerst�ren
        Destroy(gameObject);
    }
}