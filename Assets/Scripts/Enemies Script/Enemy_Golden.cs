using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Golden : Enemy_Bomb
{
    protected override void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Boolet")
        {
            gameManager.UpdateScore(5);
            Debug.Log("Jackpot!");
            Destroy(this.gameObject);
        }
    }
}
