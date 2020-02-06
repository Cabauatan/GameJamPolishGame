using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    public List<WaveScriptable> wavesScriptable;
    public List<Transform> points;
    RefugeeMovement refugee;
    bool isDone;
    bool isSpawning = true;
    int currentWave = 0;
    public int EnemiesLeft;
    List<int> originalWavenumber;
    public TextMeshProUGUI wavesText;
    void Start()
    {
        currentWave = 0;
        originalWavenumber = new List<int>();
        for(int i = 0; i < wavesScriptable.Count; i++)
        {
            originalWavenumber.Add(wavesScriptable[i].num_of_enemies);
        }
        wavesText.text = "1 / " + wavesScriptable.Count;
        EnemiesLeft = 1;
        StartCoroutine(StartSpawning());
    }

    void Update()
    {
        if(EnemiesLeft <= 0)
        {   
            EnemiesLeft = 1;
            StartCoroutine(StartSpawning());
            wavesText.text = (currentWave + 1).ToString() + " / " + wavesScriptable.Count.ToString();
        }
    }
    IEnumerator StartSpawning()
    {
        isSpawning = true;
        if(currentWave < originalWavenumber.Count - 1) 
        {
            EnemiesLeft = wavesScriptable[currentWave].num_of_enemies;
        }
        yield return new WaitForSeconds(5.0f);
        while(isSpawning){
            if(currentWave >= originalWavenumber.Count - 1) 
            {
                break;
            }
            yield return new WaitForSeconds(1.0f / wavesScriptable[currentWave].spawnRate);
            int randomPoint = Random.Range(0, points.Count);
            refugee = Instantiate(wavesScriptable[currentWave].refugee);
            refugee.transform.position = points[randomPoint].position;
            refugee.waypoints = points[randomPoint].GetComponent<Pathway>().waypoints;
            refugee.OnReachedTarget += DeductEnemy;
            StartCoroutine(refugee.FindPath());
            originalWavenumber[currentWave]--;
            isDone = originalWavenumber[currentWave] == 0;
            if(isDone) 
            {
                isSpawning = false;
                currentWave++;
                
            }
            
        }
    }

    void DeductEnemy()
    {
        Debug.Log("adassasadada");
        EnemiesLeft--;
    }

}
