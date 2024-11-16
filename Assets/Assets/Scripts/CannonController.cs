using UnityEngine;

public class CannonController : Weapon
{
    public float maxYRotation;
    public float minYRotation;
    public float maxXRotation;
    public float minXRotation;
    public float rotationSpeed;

    public Transform barrelTransform;
    public Transform baseTransform;
    public Transform firePoint;

    private bool fireDisabled;

    public void DisableFire()
    {
        fireDisabled = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        AimCannon();
        TryFireCannon();
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    protected override  void AimCannon()
    {
        float newbaserotation = baseTransform.localRotation.eulerAngles.y + rotationSpeed * Input.GetAxis("Mouse X");
        newbaserotation = Mathf.Clamp(newbaserotation,minYRotation,maxYRotation);
        baseTransform.localRotation = Quaternion.Euler(0,newbaserotation,0);
        
       float newbaserotationvert = barrelTransform.localRotation.eulerAngles.x - rotationSpeed * Input.GetAxis("Mouse Y");
       newbaserotationvert = Mathf.Clamp(newbaserotationvert,minXRotation,maxXRotation);
       barrelTransform.localRotation = Quaternion.Euler(newbaserotationvert,0,0);
    }

    protected override void TryFireCannon()
    {
        if (fireDisabled || !Input.GetButtonDown("Fire1"))
        return;
            //Debug.Log("Fire!");
           cannonball InstantiatedBall = Instantiate(projectilePrefab,firePoint.position, Quaternion.identity);
           InstantiatedBall.SetUp(firePoint.forward * projectileFireForce);
        
    }
}