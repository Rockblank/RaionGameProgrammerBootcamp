using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemySpeed = 50f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0,0,5);
        transform.position -= direction * enemySpeed*Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "boundaries" || other.gameObject.tag == "Boolet")
        {
            Destroy(gameObject);
        }
    }
}
