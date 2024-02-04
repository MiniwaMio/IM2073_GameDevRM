using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;

    [SerializeField]
    private float zombieInterval = 5f;

    [SerializeField]
    public int maxZombie = 50;
    [SerializeField]
    public int currentZombie = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(zombieInterval, zombiePrefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if(currentZombie <= maxZombie)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(23, 0, 23), Quaternion.identity);
            currentZombie += 1;
        }
        StartCoroutine(spawnEnemy(interval, enemy));

    }

}

