using System.Collections;
using UnityEngine;

public class Scythe : BaseWeapon
{
    //[SerializeField] GameObject scytheProjectile;
    [SerializeField] SimpleObjectPool scytheProjectilePool;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnScytheCoroutine());
    }

    private IEnumerator SpawnScytheCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < level * 10; i++)
            {
                float randomAngle = UnityEngine.Random.Range(0, 360f);
                //Instantiate(scytheProjectile, player.transform.position, Quaternion.Euler(0, 0, randomAngle));
                var scytheProjectile = scytheProjectilePool.GetObject();
                scytheProjectile.transform.position = player.transform.position;
                scytheProjectile.transform.rotation = Quaternion.Euler(0, 0, randomAngle);
                scytheProjectile.SetActive(true);
            }
        }
    }
}
