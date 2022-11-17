using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool isBoss;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] GameObject crystalPrefab;
    protected GameObject player;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (isBoss)
        {
            StartCoroutine(BossCameraCoroutine());
        }
    }

    IEnumerator BossCameraCoroutine()
    {
        Time.timeScale = 0;
        Camera.main.GetComponent<PlayerCamera>().target = gameObject;
        Camera.main.orthographicSize = 4;
        yield return new WaitForSecondsRealtime(5f);
        Camera.main.GetComponent<PlayerCamera>().target = GameObject.FindGameObjectWithTag("Player");
        Camera.main.orthographicSize = 5;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1;
    }

    protected virtual void Update()
    {
        var destination = player.transform.position;
        var source = transform.position;
        var direction = destination - source;
        direction.Normalize();

        transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);

        transform.position += direction * Time.deltaTime * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            if (player.Damage())
            {
                Destroy(gameObject);
            }
        }
    }

    internal void Damage()
    {
        Instantiate(crystalPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
