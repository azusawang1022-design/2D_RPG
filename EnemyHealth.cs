using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Slider slider;

    private EnemyMovement enemyMovement;
    private Rigidbody2D rb;


    private void Start()
    {
        currentHealth = maxHealth;
        enemyMovement = GetComponent<EnemyMovement>();
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }
    private void LateUpdate()
    {
        if (slider != null)
        {
            slider.transform.localScale = new Vector3(
                transform.localScale.x < 0 ? -1 : 1   ,
                1 ,
                1 
            )* 0.003f;
        }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        slider.value = currentHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        else if (currentHealth <= 0)
        {
            if (enemyMovement != null)
            enemyMovement.ChangeState(EnemyState.Dead);
            Destroy(slider.gameObject);
        }

    }

}
