using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{
    public charMvScript character;
    public Spawner Tower;

    public List<Button> buttons;
    public List<string> upgrades;
    public List<Sprite> icon;
    public TextMeshProUGUI currentCost;
    public GameObject warningText;
    private int Cost;
    public charCarryScript m_character;

    public CoinAppear coinManager;

    void Start()
    {
        Cost = 5;
        currentCost.text = "COST: " + Cost.ToString("N0");
        ProcessChoices();
        InitializeButtons();
    }

    public void ProcessChoices()
    {
        warningText.SetActive(false);
        for(int i = 0; i < buttons.Count; i++){
            int randomIndex = Random.Range(0, upgrades.Count);
            buttons[i].GetComponent<Image>().overrideSprite = icon[randomIndex];
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = upgrades[randomIndex];

        }
    }
    void InitializeButtons()
    {
        for(int i = 0; i < buttons.Count; i++){
            int buttonIndex = i;
            
            buttons[i].onClick.AddListener(() => {Upgrade(buttonIndex);});

        }
    }

    void Upgrade(int index)
    {
        string upgradeButtonDesc = buttons[index].GetComponentInChildren<TextMeshProUGUI>().text;
        if(PlayerPrefs.HasKey("DNA"))
        {
            if(PlayerPrefs.GetInt("DNA") >= Cost)
            {
                if(upgradeButtonDesc.ToUpper().Contains("HEALING POWER"))
                {
                    Tower.healPower += 10;
                }
                else if(upgradeButtonDesc.ToUpper().Contains("HEALING SPEED"))
                {
                    Tower.healPower += 2;
                }
                    else if(upgradeButtonDesc.ToUpper().Contains("HEALING RANGE"))
                {
                    Tower.range += 2;
                }
                else if(upgradeButtonDesc.ToUpper().Contains("CHARACTER MOVEMENT"))
                {
                    character.BaseMvSpd += 2;
                }
                else if(upgradeButtonDesc.ToUpper().Contains("DNA GAIN"))
                {
                    coinManager.coinGain += 2;
                }
                
                PlayerPrefs.SetInt("DNA", (PlayerPrefs.GetInt("DNA") - Cost));
                Cost *= 2;
                currentCost.text = "COST: " + Cost.ToString("N0");
                m_character.fncCharCarry();
                coinManager.UpdateCoins();
            }
            else {
                warningText.SetActive(true);
            }
        }
    }
}
