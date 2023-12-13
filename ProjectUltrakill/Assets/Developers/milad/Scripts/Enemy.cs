using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health;

    static EnemyManager manager;

    bool hasAttacked;

    private void Start()
    {
        manager = GetComponent<EnemyManager>();
    }
    private void Update()
    {
        if (health <= 0)
        {
            if (manager != null)
            {
                manager.enemiesAlive--;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasAttacked)
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("Attacking!");
        StartCoroutine(AttackCooldown(1f));
        hasAttacked = true;
    }

    IEnumerator AttackCooldown(float atkDelay)
    {
        yield return new WaitForSeconds(atkDelay);
        hasAttacked = false;
    }
}
