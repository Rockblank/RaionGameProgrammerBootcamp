using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float projectileFireForce;
    public cannonball projectilePrefab;

    private void Update()
    {
        AimCannon();
        TryFireCannon();
    }

    protected abstract void AimCannon();
    protected abstract void TryFireCannon();
}
