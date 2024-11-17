using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaionLatihanLogixc : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 8f;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementVert = Input.GetAxisRaw("Vertical");
        float movementHori = Input.GetAxisRaw("Horizontal");
        Vector3 movemenntDirection = new Vector3();
        movemenntDirection.z = movementVert;
        movemenntDirection.x = movementHori;

        transform.position += movemenntDirection * movementSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject spawnBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Destroy(spawnBullet, 1.5f);
        }
    }
}
