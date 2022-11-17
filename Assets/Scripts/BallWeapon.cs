using System.Collections;
using UnityEngine;

public class BallWeapon : BaseWeapon
{
    [SerializeField] GameObject ballProjectile;
    private GameObject player;

    private void Start()
    {
        player = transform.parent.gameObject;
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            var spawnPos = UnityEngine.Random.insideUnitCircle * 4f;
            Instantiate(ballProjectile, spawnPos, Quaternion.identity); 
        }
    }
}
