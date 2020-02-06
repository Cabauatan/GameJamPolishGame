using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTrigUpgrade : MonoBehaviour
{

    public charCarryScript charSys;
    public GameObject panelShop, objTower;
    public bool upgrading;
    public UpgradeSystem system;
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (charSys.isCarry == false && col.gameObject.GetComponent<Spawner>())
        {
            
            print(charSys.isCarry + " carrying " + (col.gameObject == objTower).ToString());
            fncUpgradeMode(true);
            upgrading = true;
            system.ProcessChoices();
        }
            
    }
    void FixedUpdate()
    {
        print(upgrading + " carrying " + (!charSys.isCarry).ToString());
        fncUpgradeMode(
            upgrading
            &&
            !charSys.isCarry
            );
    }

    public void fncUpgradeMode(bool getBool)
    {
        print("///upgrades");
        panelShop.SetActive(getBool);

        if (getBool) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void endUpgrade()
    {
        fncUpgradeMode(false);
    }


}
