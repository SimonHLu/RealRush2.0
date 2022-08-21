using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))] // This automates sending the Enemy script into the gameObject when EnemyHealth
// is added to the object.
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoints = 0;
    // Start is called before the first frame update
    Enemy enemy;
    void OnEnable()
    {
        // make HP increase everytime they die.
        currentHitPoints = maxHitPoints;
    }

    void Start() {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) {
        ProccessHit();
    }

   void ProccessHit()
    {
        currentHitPoints--;
        if(currentHitPoints <= 0)
        {
             gameObject.SetActive(false);
             maxHitPoints += difficultyRamp;
             enemy.RewardGold(); // This comes from the Enemy.cs script
        }
    }
}
