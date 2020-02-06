using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CityLife : MonoBehaviour
{
    public int maxLife;
    public int currentLife;
    public List<Image> heartImages;
    public Sprite halfHeart;
    public Sprite fullHeart;

    [SerializeField]GameObject objGameOver;
    void Start()
    {
        currentLife = maxLife;
        UpdateHearts();
    }

    void UpdateHearts()
    {
        switch(currentLife){
            case 0:
                heartImages[0].gameObject.SetActive(false);
                heartImages[1].gameObject.SetActive(false);
                heartImages[2].gameObject.SetActive(false);
                heartImages[3].gameObject.SetActive(false);
                heartImages[4].gameObject.SetActive(false);
                break;
            case 1:
                heartImages[0].overrideSprite = halfHeart;
                heartImages[1].gameObject.SetActive(false);
                heartImages[2].gameObject.SetActive(false);
                heartImages[3].gameObject.SetActive(false);
                heartImages[4].gameObject.SetActive(false);
                break;
            case 2:
                heartImages[0].overrideSprite = fullHeart;
                heartImages[1].gameObject.SetActive(false);
                heartImages[2].gameObject.SetActive(false);
                heartImages[3].gameObject.SetActive(false);
                heartImages[4].gameObject.SetActive(false);
                break;
            case 3:
                heartImages[0].overrideSprite = fullHeart;
                heartImages[1].overrideSprite = halfHeart;
                heartImages[2].gameObject.SetActive(false);
                heartImages[3].gameObject.SetActive(false);
                heartImages[4].gameObject.SetActive(false);
                break;
            case 4:
                heartImages[0].overrideSprite = fullHeart;
                heartImages[1].overrideSprite = fullHeart;
                heartImages[2].gameObject.SetActive(false);
                heartImages[3].gameObject.SetActive(false);
                heartImages[4].gameObject.SetActive(false);
                break;
            case 5:
                heartImages[0].overrideSprite = fullHeart;
                heartImages[1].overrideSprite = fullHeart;
                heartImages[2].overrideSprite = halfHeart;
                heartImages[3].gameObject.SetActive(false);
                heartImages[4].gameObject.SetActive(false);
                break;
            case 6:
                heartImages[0].overrideSprite = fullHeart;
                heartImages[1].overrideSprite = fullHeart;
                heartImages[2].overrideSprite = fullHeart;
                heartImages[3].gameObject.SetActive(false);
                heartImages[4].gameObject.SetActive(false);
                break;
            case 7:
                heartImages[0].overrideSprite = fullHeart;
                heartImages[1].overrideSprite = fullHeart;
                heartImages[2].overrideSprite = fullHeart;
                heartImages[3].overrideSprite = halfHeart;
                heartImages[4].gameObject.SetActive(false);
                break;
            case 8:
                heartImages[0].overrideSprite = fullHeart;
                heartImages[1].overrideSprite = fullHeart;
                heartImages[2].overrideSprite = fullHeart;
                heartImages[3].overrideSprite = fullHeart;
                heartImages[4].gameObject.SetActive(false);
                break;
            case 9:
                heartImages[0].overrideSprite = fullHeart;
                heartImages[1].overrideSprite = fullHeart;
                heartImages[2].overrideSprite = fullHeart;
                heartImages[3].overrideSprite = fullHeart;
                heartImages[4].overrideSprite = halfHeart;
                break;
            case 10:
                heartImages[0].overrideSprite = fullHeart;
                heartImages[1].overrideSprite = fullHeart;
                heartImages[2].overrideSprite = fullHeart;
                heartImages[3].overrideSprite = fullHeart;
                heartImages[4].overrideSprite = fullHeart;
                break;
        }
    }

    public void Damage(int damageAmount)
    {
        currentLife -= damageAmount;

        if(currentLife <= 0)
        {
            currentLife = 0;
            UpdateHearts();
            Time.timeScale = 0;
            //initGameOver
            objGameOver.SetActive(true);
        }

        UpdateHearts();
        //Debug.Log(currentLife);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        RefugeeLife refugee = other.GetComponent<RefugeeLife>();
        if(refugee)
        {   
            Damage(1);

        }
        
    }

}
