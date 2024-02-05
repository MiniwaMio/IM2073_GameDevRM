using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;

    [SerializeField]
    private float zombieInterval = 6f;

    [SerializeField]
    public int maxZombie = 25;
    [SerializeField]
    public int currentZombie = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Triggered");
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
            GameObject newEnemy = Instantiate(enemy, new Vector3(704+Random.Range(5,-5), 25, 431 + Random.Range(5, -5)), Quaternion.identity);
            GameObject newEnemy1 = Instantiate(enemy, new Vector3(238 + Random.Range(5, -5), 25, 480 + Random.Range(5, -5)), Quaternion.identity);
            GameObject newEnemy2 = Instantiate(enemy, new Vector3(283 + Random.Range(5, -5), 25, 552 + Random.Range(5, -5)), Quaternion.identity);
            GameObject newEnemy3 = Instantiate(enemy, new Vector3(508 + Random.Range(5, -5), 38, 618 + Random.Range(5, -5)), Quaternion.identity);
            GameObject newEnemy4 = Instantiate(enemy, new Vector3(563 + Random.Range(5, -5), 25, 412 + Random.Range(5, -5)), Quaternion.identity);
            currentZombie += 5;
        }
        StartCoroutine(spawnEnemy(interval, enemy));

    }

}

