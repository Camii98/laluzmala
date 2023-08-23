using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int maxHealth = 5;
    int currentHealth;
    private Animator eAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        eAnimator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        eAnimator.SetTrigger("damaged");
        currentHealth -= damage;

        if(currentHealth <=0)
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        Debug.Log("Enemy died");
        eAnimator.SetBool("is_Alive",false);
        yield return new WaitForSecondsRealtime(4);
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
        yield break;
    }
}
