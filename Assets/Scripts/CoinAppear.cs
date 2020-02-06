using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinAppear : MonoBehaviour
{
    public List <Transform> pointToAppear = new List<Transform>();
    public bool haveActive = false;
    int rand;
    public TextMeshProUGUI YourCoinText;
     public int coinGain;
    void Start()
    {
        checIfAppear();
        PlayerPrefs.SetInt("DNA", 0);
    }
    public void UpdateCoins()
    {
        YourCoinText.text = PlayerPrefs.GetInt("DNA").ToString("N0");
    }

    IEnumerator StartCoinSpawning()
    {
        
        yield return new WaitForSeconds(3.0f);

        rand = Random.Range(0,(pointToAppear.Count));
        
        Debug.Log("POINTS TO APPEAR: " + pointToAppear.Count.ToString());
        if(!haveActive)
        {
            Debug.Log("RANDOM: " + rand);
            pointToAppear[rand].gameObject.SetActive(true);
            haveActive = true;
        }
    }

    public void StartCoroutineSpawn()
    {
        StartCoroutine(StartCoinSpawning());
    }
    public void checIfAppear()
    {
        for(int i=0;i<pointToAppear.Count;i++)
        {
            if(pointToAppear[i].gameObject.activeSelf == true)
            {
                break;
                return;
            }
            else
            {
                haveActive = false;
                StartCoroutineSpawn();
            }
        }
    }
}
