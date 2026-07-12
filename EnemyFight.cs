using UnityEngine;

public class EnemyFight : MonoBehaviour


{
    [SerializeField] private int power = 5;
    public Transform attackPoint;
    public float weaponRange;
    public float knockPower;
    public float StunTime;

    public LayerMask playerLayer;


    public void Attack()
    {
        Debug.Log("Attack");
        Debug.Log(attackPoint);
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        Debug.Log("Hit Count = " + hits.Length);

        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-power);
            hits[0].GetComponent<PlayerControl>().GetKnocked(transform, knockPower, StunTime);
        }
    }

}
