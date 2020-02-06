using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int LEFT_MOUSE_BUTTON = 0;
    [SerializeField] private FiringBullet m_bullet;
    public float speed;
    public Transform CurrentTarget;
    public float fireRate;
    public float range;
    public Collider2D[] enemies;
    FiringBullet spawnedBullet;
    bool startFire = true;
    public int healPower;
    void Start()
    {
        StartFire();
    }

    void Update()
    {
        enemies = Physics2D.OverlapCircleAll(transform.position, range,1 << 8);
        
    }

    IEnumerator Fire()
    {
        while(startFire) {
            yield return null;
            Debug.Log(enemies.Length);
            while(enemies.Length > 0)
            {
                yield return null;
                for(int i = 0; i < enemies.Length; i++) {
                    if(enemies[i].GetComponent<RefugeeLife>()) {
                        Transform enemyPosition = enemies[i].transform;
                        yield return new WaitForSeconds(1.0f/fireRate);
                        spawnedBullet = Instantiate(m_bullet);
                        spawnedBullet.transform.position = transform.position;
                        spawnedBullet.p_speed = speed;
                        spawnedBullet.Target = enemyPosition;
                        spawnedBullet.healPower = healPower;
                        break;
                    }
                }
                
            } 
        }

    }

    public void StartFire()
    {
        startFire = true;
        StartCoroutine(Fire());
        
    }

    public void StopFire()
    {
        startFire = false;
        StopAllCoroutines();
        
    }
}