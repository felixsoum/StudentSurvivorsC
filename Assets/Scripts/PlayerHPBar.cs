using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] Image foreground;
    Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        transform.position = player.transform.position + Vector3.up;

        float hpRatio = player.hp / 100f;
        foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
    }

}
