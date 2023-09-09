using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health_Enemy : MonoBehaviour
{
    public float maxHealth = 2;
    public float currentHealth = 2;
    Animator animator;
    public float damage;
    public GameObject ItemDrop;
    
    UI_HealthBarEnemy healthBar;

    spawnEnemy enemyCount;

    void Start()
    {
        maxHealth = currentHealth;
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<UI_HealthBarEnemy>();
        enemyCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<spawnEnemy>();
    }
    void TakeDamege(float amount)
    {
        currentHealth -= amount;
        healthBar.setHealth(currentHealth / maxHealth);
        if (currentHealth <= 0.00f)
        {
            StartCoroutine("Die");
        }
        Destroy(GameObject.FindGameObjectWithTag("Bullet"));
    }
    
    IEnumerator Die()
    {
        animator.SetBool("E_Death", true);
        yield return new WaitForSeconds(1.3f); 
        Destroy(gameObject);
        enemyCount.enemyCurrentCount--;
        var item = Instantiate(ItemDrop, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamege(damage);
        }
    }
}