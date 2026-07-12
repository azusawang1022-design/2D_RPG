using System.Collections;
using UnityEngine;

public class EnemyKnocked : MonoBehaviour
{
    private Rigidbody2D rb;
    private EnemyMovement enemyMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public void Knocked(Transform playerTransform, float knockPower, float stunTime)
    {
        enemyMovement.ChangeState(EnemyState.Knocked);
        StartCoroutine(StunTimer(stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;

        rb.linearVelocity = direction * knockPower;
    }

    IEnumerator StunTimer(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        enemyMovement.ChangeState(EnemyState.Idle);
    }
}
