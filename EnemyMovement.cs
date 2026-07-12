using UnityEngine;
using UnityEngine.XR;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform player;
    public Animator anim;


    public float speed;
    public float attackRange;
    public float attackCoolDown = 2;
    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    public EnemyState enemyState, newState;


    private int facingDirection = 1;
    private float attackCoolDownTimer;
    


    

//————————START AND UPDATE————————
    void Start()
    {  
        rb = GetComponent<Rigidbody2D>();
        anim.GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
        //Start with Idle state
    }


    void Update()
    {
         if (enemyState != EnemyState.Knocked)
        {
            PlayerCheck();

            if (attackCoolDownTimer > 0)
            {
                attackCoolDownTimer -= Time.deltaTime;
            }

            if (enemyState == EnemyState.Run)
            {
                Run();
            }
            else if (enemyState == EnemyState.Attack)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
//————————START AND UPDATE————————
        void flip()
        {
            facingDirection *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
//————————CHECK & CHASE & ATTACK FUNCTION————————
        void Run()
        {

            if (player.position.x > transform.position.x && facingDirection == -1 ||
       player.position.x < transform.position.x && facingDirection == 1)
            {
                flip();
            }
            //Change direction to player

            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;

        }
    }
    private void PlayerCheck()
    {

        if (enemyState == EnemyState.Attack)
            return;
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);

        if(hits.Length > 0)
        {
            player = hits[0].transform;

            if (Vector2.Distance(transform.position, player.position) <= attackRange &&
                attackCoolDownTimer <= 0)
            {
                attackCoolDownTimer = attackCoolDown;
                ChangeState(EnemyState.Attack);
            }//Check Player in range and cooldown is over

            else if(Vector2.Distance(transform.position, player.position) > attackRange)
            {
                ChangeState(EnemyState.Run);
            }//Player out of range and Chase
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    //————————CHECK & CHASE & ATTACK FUNCTION————————


    //————————STATE CHANGE FUNCTION————————
    public void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.Dead) return;
        
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Run)
            anim.SetBool("Chasing", false);
        else if (enemyState == EnemyState.Attack)
            anim.SetBool("Attacking", false);
        else if (enemyState == EnemyState.Knocked)
            anim.SetBool("Knocked", false);
        else if (enemyState == EnemyState.Dead)
            anim.SetBool("Dead", false);
        //Exit Current Animation

        enemyState = newState;
        //Update current state

        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", true);
        else if (enemyState == EnemyState.Run)
            anim.SetBool("Chasing", true);
        else if (enemyState == EnemyState.Attack)
            anim.SetBool("Attacking", true);
        else if (enemyState == EnemyState.Knocked)
            anim.SetBool("Knocked", true);
        else if (enemyState == EnemyState.Dead)
        {
            rb.simulated = false;
            anim.SetBool("Dead", true);
        }
            

        //Enter newState
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }
}

    public enum EnemyState
{
    Idle,
    Run,
    Attack,
    Knocked,
    Dead,
}
//————————STATE CHANGE FUNCTION————————