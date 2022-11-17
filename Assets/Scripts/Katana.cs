using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : BaseWeapon
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D boxCollider2D;

    private void Start()
    {
        StartCoroutine(KatanaCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage();
        }
    }

    private IEnumerator KatanaCoroutine()
    {
        while (true)
        {
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;

            yield return new WaitForSeconds(2f);
            spriteRenderer.enabled = true;
            boxCollider2D.enabled =  true;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
