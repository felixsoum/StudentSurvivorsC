using UnityEngine;

public class ScytheProjectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage();
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
