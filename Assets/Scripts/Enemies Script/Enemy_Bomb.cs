using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bomb : Enemy
{
    protected override void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Boolet")
        {
            gameManager.UpdateScore(-5);
            Debug.Log("Dor kena bomb!");
            Destroy(this.gameObject);
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "boundaries")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Swiper")
        {
            gameManager.UpdateScore(1);
            Destroy(this.gameObject);
        }
    }
}
