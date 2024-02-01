using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;

    [SerializeField]
    private float zombieInterval = 3.5f;

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
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f,5), 0, Random.Range(-5f, 5)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
