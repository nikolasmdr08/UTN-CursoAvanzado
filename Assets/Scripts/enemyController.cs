using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            dead();
        }    
    }

    void ApplyDamage(float damage) {
        health -= damage;
        Debug.Log(health);
    }

    void dead() {
        Destroy(gameObject);
    }
}
