using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerGame : MonoBehaviour
{
    public GameObject enemy;
    public float intervalTime = 8f;
    public float currentInterval = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentInterval += Time.deltaTime;
        if (currentInterval > intervalTime)
        {
            currentInterval = 0;
            GameObject spawningEnemy = Instantiate(enemy,transform.position,Quaternion.identity);
        }
    }
}
