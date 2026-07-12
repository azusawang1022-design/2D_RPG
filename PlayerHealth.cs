using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    public Slider slider;

    private bool isDead;


    public Animator anim;

    void Start()
    {
        
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    void Update()
    {

    }

    public void ChangeHealth( int amount)
    {
        if (isDead) return;
        currentHealth += amount;
        slider.value = currentHealth;

        if( currentHealth <= 0)
        {
            PlayerControl playercontrol = GetComponent<PlayerControl>();
            playercontrol.enabled = false;
            PlayerFight playerfight = GetComponent<PlayerFight>();
            playerfight.enabled = false;
            
            gameObject.layer = LayerMask.NameToLayer("Default");


            anim.SetBool("Dead", true);

            return;

        }
        if (amount < 0) 
        {
            anim.SetTrigger("healthChange");
        }
       
    }


}
