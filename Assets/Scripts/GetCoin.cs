using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetCoin : MonoBehaviour
{
    public GameObject parent;
    public CoinAppear appear;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        charMvScript characterPlayer = other.GetComponent<charMvScript>();
        if(characterPlayer)
        {
            appear.haveActive = false;
            parent.SetActive(false);
            appear.checIfAppear();
            PlayerPrefs.SetInt("DNA", (PlayerPrefs.GetInt("DNA") + appear.coinGain));
            Debug.Log("            DNA             " + PlayerPrefs.GetInt("DNA"));
            appear.UpdateCoins();
        }
    }
}
    
