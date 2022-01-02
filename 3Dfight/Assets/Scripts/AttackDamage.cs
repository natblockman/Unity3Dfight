using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public LayerMask layer;
    public float radius = 1f;
    public float damage = 1f;
   

    // Update is called once per frame
    void Update()
    {
        Collider[] hit=Physics.OverlapSphere(transform.position, radius,layer);

        if (hit.Length > 0)
        {
          hit[0].GetComponent<HealthScript>().ApplyDamage(damage);
          gameObject.SetActive(false);
        }
    }
}
