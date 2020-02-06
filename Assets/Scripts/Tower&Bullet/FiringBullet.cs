using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBullet : MonoBehaviour
{
    [HideInInspector]public float p_speed;
    public Transform Target;
    
    public int healPower;
    void Update()
    {
        Vector3 m_dir = Target.position - transform.position;
        transform.position += m_dir.normalized * p_speed * Time.deltaTime;
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        RefugeeLife refugee = other.GetComponent<RefugeeLife>();
        if(refugee)
        {   
            refugee.Heal(healPower);
        }
        if(other.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
