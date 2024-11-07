using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshealth : MonoBehaviour
{
    public float health = 50f;  // “G‚Ì‘Ì—Í
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0f)
        {
            Die();
        }
        StartCoroutine(Flash());
    }

    void Die()
    {
        Destroy(gameObject); // “G‚ðÁ‚·
    }

    private IEnumerator Flash()
    {
        spriteRenderer.color = Color.red; // “_–ÅF
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

}
