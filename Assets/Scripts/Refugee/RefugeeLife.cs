using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;
public class RefugeeLife : MonoBehaviour
{
    public int maxLife;
    public int currentLife;
    FiringBullet bullet;
    
    public SpriteMeshInstance renderer;
    public SpriteMesh sprite;

    public GameObject sad;
    public GameObject happy;
    public Transform replace;
    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = 0;
        //renderer.spriteMesh = sprite;
    }

    // Update is called once per frame
    public void Heal(int healAmount)
    {
        currentLife += healAmount;
        particleSystem.Play();
        if(currentLife >= maxLife){
            currentLife = maxLife;
            sad.SetActive(false);
            happy.SetActive(true);
            Debug.Log("DEAD");
            Destroy(GetComponent<RefugeeLife>());
        }

        //Debug.Log(currentLife);
    }
}
