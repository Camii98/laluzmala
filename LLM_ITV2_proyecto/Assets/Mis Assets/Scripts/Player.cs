using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    private Animator mAnimator;

    public float respawnDelay = 1f;
    public float moveDelay = 125f;

    vThirdPersonInput _Move;

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    
    public LayerMask bastards;
    public HealthBar healthBar;
    public BoxCollider attackRange;
    public Transform attackPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        mAnimator = GetComponent<Animator>();

        _Move = gameObject.GetComponent<vThirdPersonInput>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack(0);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Attack(1);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            mAnimator.SetTrigger("TrDeath");
            move();
            Invoke("Respawn", respawnDelay);
            healthBar.SetHealth(currentHealth);
        }
        {
            healthBar.SetHealth(currentHealth);
        }
    }
    void Respawn ()
    {
        mAnimator.SetTrigger("TrStand");
        player.transform.position = respawnPoint.transform.position;
        
        
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        Debug.Log("wait");
        Invoke("move", moveDelay);      
    }
    void move()
    {
        _Move.enabled = !_Move.enabled;
        Debug.Log("NOW");
    }

    void Attack(int attack_type)
    {

        if(attack_type == 0)
        {
            mAnimator.SetTrigger("small_attack");
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position,0.5f,bastards);
            foreach (Collider enemy in hitEnemies){
                Debug.Log("take that");
                Debug.Log(enemy.name);
                enemy.GetComponent<EnemyBehavior>().TakeDamage(2);
            }
        }
        else if(attack_type == 1)
        {
            mAnimator.SetTrigger("Big_attack");
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position,0.8f,bastards);
            foreach (Collider enemy in hitEnemies){
                Debug.Log("take that");
                Debug.Log(enemy.name);
                enemy.GetComponent<EnemyBehavior>().TakeDamage(3);
            }
        };
    }

}

