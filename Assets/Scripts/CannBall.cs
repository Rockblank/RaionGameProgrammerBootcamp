using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannBall : MonoBehaviour
{
    public static int animatorhash = Animator.StringToHash("Exploded");

    protected Rigidbody rigid;
    public Animator anmrtr;

    public float explosionForce = 9.0f;
    public float explosionRadius = 7.0f;
    public float explosionUpwarModifier = 1.0f;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetUp(Vector3 fireforce)
    {
        rigid.AddForce(fireforce, ForceMode.Impulse);
        rigid.angularVelocity = new Vector3(Random.Range(-10,10),Random.Range(-10,10),Random.Range(-10,10));
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        rigid.angularVelocity = Vector3.zero;
        rigid.velocity = Vector3.zero;
        rigid.isKinematic = true;
        rigid.detectCollisions = false;

        anmrtr.SetTrigger(animatorhash);

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius, LayerMask.GetMask("Targets"));
        
        foreach (Collider hit in colliders)
        {
            Rigidbody rigidexplode = hit.GetComponent<Rigidbody>();

            if (rigidexplode != null)
            {
                rigidexplode.AddExplosionForce(explosionForce,explosionPos,explosionRadius,explosionUpwarModifier,ForceMode.Impulse);
            }
        }
    }
    public void OnFinishedExplosionAnimation()
    {
        Destroy(gameObject);
    }
    
    public void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
