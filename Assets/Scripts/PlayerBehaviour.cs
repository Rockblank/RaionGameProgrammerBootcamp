using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Transform cannonBase;
    public Transform barrelCannon;
    public Transform firePoint;

    public GameObject bullet;
    public float minRotationBase;
    public float maxRotationBase;
    public float minRotationBarrel;
    public float maxRotationBarrel;
    public float minXlocation;
    public float maxXlocation;
    public float minZlocation;
    public float maxZlocation;
    public float rotationSpeed;
    public float playerSpeed;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    // Update is called once per frame
    void Update()
    {
        movement();
        rotationCannon();

        if (Input.GetMouseButtonDown(0))
        {
            fireCannon();
        }
    }
    void rotationCannon()
    {
        float angleNormal = normalizedAngle(cannonBase.localRotation.eulerAngles.y);
        float horizontalRotation = angleNormal + rotationSpeed * Input.GetAxis("Mouse X");
        horizontalRotation = Mathf.Clamp(horizontalRotation,minRotationBase, maxRotationBase);
        cannonBase.localRotation = Quaternion.Euler(0,horizontalRotation,0);

        //float angleNormalVert = normalizedAngle(barrelCannon.localRotation.eulerAngles.x);
        float verticalRotation = barrelCannon.localRotation.eulerAngles.x - rotationSpeed * Input.GetAxis("Mouse Y");
        verticalRotation = Mathf.Clamp(verticalRotation, minRotationBarrel, maxRotationBarrel);
        barrelCannon.localRotation = Quaternion.Euler(verticalRotation,0,0);
    }
    void movement()
    {
        float movementHori = Input.GetAxisRaw("Horizontal");
        float movementVert = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(movementHori,0,movementVert);

        Vector3 newPosition = transform.position + direction * playerSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minXlocation, maxXlocation);
        newPosition.z = Mathf.Clamp(newPosition.z, minZlocation,maxZlocation);
        transform.position = newPosition;
    }
    float normalizedAngle(float angle)
    {
        while (angle > 180) angle -= 360;
        while (angle < -180) angle += 360;
        return angle;
    }
    void fireCannon()
    {
        GameObject bulletSpawn = Instantiate(bullet,firePoint.position ,Quaternion.identity);
        bulletSpawn.GetComponent<BulletBehaviour>().setDirection(firePoint.forward);
        Destroy(bulletSpawn,2.5f);
    }
}
