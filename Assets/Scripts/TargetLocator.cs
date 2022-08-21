using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        //target = FindObjectOfType<EnemyMover>().transform; // This thing hunts down the guy with script
    }

    // Update is called once per frameS
    void Update()
    {
        FindClosestTarget(); // check to see the closest target THEN, this can be costly. Need safe guard
        // such as out of range or if enemy dies. to disable the activated object.
        AimWeapon();   // aim the weapon
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null; // Find which enemy is the closest.
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies) // searching through the enemies array
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform; // set enemy is closest
                maxDistance = targetDistance; // reduce max distance to current distance of enemy.
            }
        }
        target = closestTarget; 
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position); // stopping the infinite range.
        weapon.LookAt(target);

        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive) // turning particle systems on/off
    {
        var emissionModule = projectileParticles.emission;//ref particle emission module.
        emissionModule.enabled = isActive; // This isActive brings in info from the Attack(bool isActive)
        //  Attack(bool isActive) takes either a true or false info and holds it in isActive and then 
        // sends to another isActive inside the method.
    }
}
