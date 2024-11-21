using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemySpeed = 50f;

    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0,0,5);
        transform.position -= direction * enemySpeed*Time.deltaTime;
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Boolet")
        {
            gameManager.UpdateScore(1);
            Destroy(this.gameObject);
        }       
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "boundaries")
        {
            gameManager.UpdateMiss(1);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Swiper")
        {
            gameManager.UpdateScore(1);
            Destroy(this.gameObject);
        }
    }
}
