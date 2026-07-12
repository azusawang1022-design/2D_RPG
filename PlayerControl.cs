using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5;
    public int facingDirection = 1;
    

    private bool knocked;


    public Rigidbody2D rb;
    public Animator anim;
    public PlayerFight playerFight;


    private void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            playerFight.Attack();
        }
    }


    void FixedUpdate()
    {
        if (anim.GetBool("attacking"))
            return;
        if (knocked == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            //Get Input

            if (horizontal > 0 && transform.localScale.x < 0 ||
                horizontal < 0 && transform.localScale.x > 0)
            {
                flip();
            }


            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));
            //Setup for animator Abs Input


            rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
            //Speed and direction from Input

        }

    }
    void flip()
    {
            facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void GetKnocked(Transform enemy, float knockPower, float StunTime)
    {
        knocked = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * knockPower;
        StartCoroutine(KnockCounter(StunTime));
    }

    IEnumerator KnockCounter(float StunTime)
    {
        yield return new WaitForSeconds(StunTime);
        rb.linearVelocity = Vector2.zero;
        knocked = false;

    }


    }
