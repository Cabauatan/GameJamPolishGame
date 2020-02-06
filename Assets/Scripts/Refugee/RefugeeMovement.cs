using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RefugeeMovement : MonoBehaviour
{
    public float speed;
    public List<Transform> waypoints;
    public Action OnReachedTarget;
    
    void Update()
    {
        //StartCoroutine(DelaySpawning());
        
    }

    public IEnumerator FindPath()
    {
        int index = 0;
        while(true)
        {
            yield return null;
            Transform currentWaypoint = waypoints[index];
            Vector3 dir = currentWaypoint.position - transform.position;
            if(dir.x > 0) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x)* -1, transform.localScale.y);
            else if(dir.x < 0) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) ,transform.localScale.y);
            transform.position += dir.normalized * speed * Time.deltaTime;

            if(Vector3.Distance(currentWaypoint.position,transform.position) <= 0.1f)
            {
                if(index >= waypoints.Count - 1) break;
                index++;
            }
        }
        OnReachedTarget();
        Destroy(gameObject);
    }
}
