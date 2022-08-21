using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)]int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)]float spawnTimer = 1f;
    
    GameObject[] pool; // we gonna populate this in Awake()

    private void Awake() 
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        
        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {    
        for (int i =0; i < pool.Length; i++)
        {   
            if (pool[i].activeInHierarchy == false)//if object is Notactive, set active return early.
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator SpawnEnemy()
    {
        while(true) // if no break, will run forever. bad.
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
            
    }

}
