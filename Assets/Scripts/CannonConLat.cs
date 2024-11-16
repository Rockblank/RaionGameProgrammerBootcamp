using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CannonConLat : MonoBehaviour
{
    public Transform baseTransform;
    public Transform barrelTransform;

    public CannBall PrefabBall;
    public Transform firePoint;

    public float fireForcePower;
    
    public float minXRotation;
    public float maxXRotation;
    public float minYRotation;
    public float maxYRotation;
    public float rotationSpeed;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        AimCannon();
        FireCannon();
        Debuggingaja();
    }
    public void AimCannon()
    {
        float newbaserotation = baseTransform.localRotation.eulerAngles.y + rotationSpeed * Input.GetAxis("Mouse X");
        newbaserotation = Mathf.Clamp(newbaserotation, minYRotation,maxYRotation);
        baseTransform.localRotation = Quaternion.Euler(0,newbaserotation,0);

        float newbarrelrotation = barrelTransform.localRotation.eulerAngles.x - rotationSpeed * Input.GetAxis("Mouse Y");
        newbarrelrotation = Mathf.Clamp(newbarrelrotation,minXRotation,maxXRotation);
        barrelTransform.localRotation = Quaternion.Euler(newbarrelrotation,0,0);
    }
    public void FireCannon()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CannBall instantiatedPrefab = Instantiate(PrefabBall,firePoint.position,Quaternion.identity);
            instantiatedPrefab.SetUp(firePoint.forward * fireForcePower);
        }
    }
    public void Debuggingaja()
    {
        float dibagging = Input.GetAxis("Debug Horizontal");
        Debug.Log(dibagging);

        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("I just click down the V button aye!");
        }
    }
}
