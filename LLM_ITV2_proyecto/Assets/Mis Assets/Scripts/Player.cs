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
    public float moveDelay = 1f;

    vThirdPersonInput _Move;

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    public HealthBar healthBar;

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

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            mAnimator.SetTrigger("TrDeath");
            _Move.enabled = false;
            Invoke("Respawn", respawnDelay);
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

        
        Invoke("move", moveDelay);


    }
    void move()
    {
        _Move.enabled = true;

    }
}

