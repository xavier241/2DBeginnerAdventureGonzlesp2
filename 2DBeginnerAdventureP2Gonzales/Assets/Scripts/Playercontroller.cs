using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    
    public int maxHealth = 5;
    public float timeInvincible = 2;
    public int Health { get { return currentHealth; } }
    int currentHealth;

    bool isInvincible;
    float invincibleTimer;
    Rigidbody2D Rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 3.0f;
    

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("speed",move.magnitude);  

        
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;  
            if (invincibleTimer < 0 )
            {
                isInvincible = false;
            }

        }
        Debug.Log(horizontal);

        Vector2 position = Rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        transform.position = position;
        Rigidbody2d.MovePosition(position);
    }
    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            animator.SetTrigger("Hit");

            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}