using UnityEngine;

public class BallProjectile : MonoBehaviour
{
    private void Start()
    {
        Invoke("Die", 9f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
