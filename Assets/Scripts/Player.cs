using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] BaseWeapon[] weapons;
    [SerializeField] float speed = 1f;
    [SerializeField] Image hpBar;

    internal int currentExp;
    internal int expToLevel = 10;
    int currentLevel = 1;

    public int hp = 100;

    SpriteRenderer spriteRenderer;
    Animator animator;
    private bool isInvincible;
    Material material;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
        weapons[0].LevelUp();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        transform.position += new Vector3(inputX, inputY, 0) * speed * Time.deltaTime;

        if (inputX != 0)
        {
            transform.localScale = new Vector3(inputX > 0 ? -1 : 1, 1, 1); 
        }

        animator.SetBool("IsRunning", inputX != 0 || inputY != 0);
    }

    internal bool Damage()
    {
        if (isInvincible)
        {
            return false;
        }
        StartCoroutine(InvincibilityCoroutine());

        hp -= 25;
        if (hp <= 0)
        {
            TitleManager.saveData.deathCount++;
            SceneManager.LoadScene("Title");
            //Destroy(gameObject);
        }
        return true;
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        //spriteRenderer.color = Color.red;
        material.SetFloat("_Flash", 1);
        yield return new WaitForSeconds(0.1f);
        //spriteRenderer.color = Color.white;
        material.SetFloat("_Flash", 0);
        isInvincible = false;
    }

    internal void AddEXP()
    {
        if (++currentExp >= expToLevel)
        {
            currentExp = 0;
            expToLevel += 10;
            currentLevel++;

            int randomIndex = UnityEngine.Random.Range(0, weapons.Length);
            weapons[randomIndex].LevelUp();
        }
    }

    public float GetHPRatio()
    {
        return hp / 100f;
    }
}
