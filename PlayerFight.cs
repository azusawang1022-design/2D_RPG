using UnityEngine;
using System.Collections;
public class PlayerFight : MonoBehaviour
{
    public Animator anim;
    public Transform AttackPoint;
    public LayerMask enemyLayer;

    public int Power = 10;
    public float weaponRange = 1.5f;
    public float knockPower = 10;
    public float stunTime = 1;

    public float cooldown = 2;
    private float timer;
    public float StunTime=1;

    public Rigidbody2D rb;



    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
           
        }

    }


    public void Attack()
    {
        if(timer <= 0) 
        {
            rb.linearVelocity = Vector2.zero;
            anim.SetBool("attacking", true);

            timer = cooldown;

        }
    }

    public void DoDamage()
    {

        Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPoint.position, weaponRange, enemyLayer);
        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().ChangeHealth(-Power);
            enemies[0].GetComponent<EnemyKnocked>().Knocked(transform, knockPower,stunTime);
        }
    }
    public void AttackFinish()
    {
        anim.SetBool("attacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AttackPoint.position, weaponRange);
    }

}
