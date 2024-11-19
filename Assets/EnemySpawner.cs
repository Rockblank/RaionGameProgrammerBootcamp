using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float min;
    public float max;
    public float intervalTime = 8f;
    [SerializeField]private float currentTime = 0f;

    // Update is called once per frame
    void Update()
    {
        currentTime  += Time.deltaTime;
        if (currentTime > intervalTime)
        {
            currentTime = 0;

            float randomRange = Random.Range(min,max);
            Vector3 newPosition = new Vector3(randomRange, transform.position.y, transform.position.z);
            
            GameObject spawnEnemy = Instantiate(enemy,newPosition,Quaternion.identity);
        }
    }
}
