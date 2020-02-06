using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charCarryScript : MonoBehaviour
{
    [SerializeField] private Spawner towerFire;
    public GameObject towerbag;
    public bool isCarry;//=false;
    public GameObject objTower;
    public Transform transfCarry;
    public float carryDistance;
    public KeyCode carryButton;

    [SerializeField]
    charMvScript MvSys;
    Animator anim;

    public scriptTrigUpgrade upgrade;
    // Update is called once per frame

    void Start()
    {
        anim = GetComponent<Animator>();
        towerbag.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(carryButton)) fncCharCarry();
    }

    public void fncCharCarry()
    {
        if (isCarry)
        {
            fncDropTower();
            
        }
        else
        {
            if (fncTowerProx())
            {
                fncCarryTower();
                isCarry = true;
            }
            else { print("Tower out of range!"); }
        }
        MvSys.fncMvMode(isCarry);
        upgrade.upgrading = false; 
        upgrade.endUpgrade();
    }

    void fncDropTower()
    {
        isCarry = false;
        objTower.SetActive(true);
        Debug.Log("Start to Fire");
        towerFire.StartFire();
        objTower.transform.SetParent(null, true);
        towerbag.SetActive(false);
        objTower.transform.position = transform.position;
    }
void fncCarryTower()
    {
        
        Debug.Log("Stop to Fire");
        towerFire.StopFire();
        objTower.transform.position = transfCarry.position;
        towerbag.SetActive(true);
        objTower.transform.SetParent(transform, true);
        objTower.SetActive(false);
    }

    bool fncTowerProx()
    {
        return Vector2.Distance(transform.transform.position, objTower.transform.position) < carryDistance;
    }
}
