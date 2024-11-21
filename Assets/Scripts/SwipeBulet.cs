using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeBulet : MonoBehaviour
{
    public float swiperSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward*swiperSpeed*Time.deltaTime;   
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide dengan: "+other.gameObject.name);
        if(other.gameObject.tag == "Win")
        {
            Destroy(this.gameObject);
        }
    }
}
