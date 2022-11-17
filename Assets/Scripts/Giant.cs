using UnityEngine;

public class Giant : Enemy
{
    enum GiantState
    {
        Idling,
        Chasing,
        Attacking
    }

    [SerializeField] GameObject giantKnifePrefab;
    GiantState currentState = GiantState.Idling;
    Animator animator;
    float waitTime = 2f;

    protected override void Start()
    {
        base.Start();
        animator  = GetComponent<Animator>();
    }

    protected override void Update()
    {
        switch (currentState)
        {
            case GiantState.Idling:
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    currentState = GiantState.Chasing;
                }
                break;
            case GiantState.Chasing:
                if (Vector3.Distance(transform.position, player.transform.position) > 5f)
                {
                    animator.SetBool("IsWalking", true);
                    base.Update();
                }
                else
                {
                    animator.SetBool("IsWalking", false);
                    currentState = GiantState.Attacking;
                }
                break;
            case GiantState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 5f;
                currentState = GiantState.Idling;
                break;
        }
    }

    public void OnAttack()
    {
        Instantiate(giantKnifePrefab, transform.position, Quaternion.identity);
    }
}
