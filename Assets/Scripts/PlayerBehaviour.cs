﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Transform cannonBase;
    public Transform barrelCannon;
    public Transform firePoint;

    public GameObject bullet;
    public GameObject SuperBullet;
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
    public GameManager gameManager;
    Boolean invincible = false;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            SuperSwipes();
        }
        if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
        {
            invincible = true;
            Debug.Log("YOU ARE INVINCIBLE!");
        }
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1) )
        {
            invincible = false;
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
        Destroy(bulletSpawn,1.5f);
    }
    void SuperSwipes()
    {
        GameObject Swipe = Instantiate(SuperBullet,firePoint.position ,Quaternion.identity);
        Destroy(Swipe,4.5f);
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy" && invincible == false)
        {
            Time.timeScale = 0;
            GetComponent<PlayerBehaviour>().enabled = false;
            gameManager.GameOver();
        } else if (other.gameObject.tag == "Enemy" && invincible == true)
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(1);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Win")
        {
            Time.timeScale = 0;
            GetComponent<PlayerBehaviour>().enabled = false;
            gameManager.WinUI();
        }
    }
}
