using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameUISys : MonoBehaviour
{
    [Range(0,5)]public int Wave;
    [Range(0,999)]public int Money;

    public int getMoni { get { return Money; } }
    [Range(0,1)]public float Health;
    public TextMeshProUGUI WaveCntr, MoniCntr;
    public List<Image> heartCntr; public Sprite heartFull, heartHalf, heartEmpty;

    void OnGUI()
    {
        updateWave();
        updateMoni();
        updateHealth();
    }

    void updateWave()
    { WaveCntr.text = Wave.ToString()+"/5"; }
    void updateMoni()
    { MoniCntr.text = Money.ToString() + "/999"; }
    void updateHealth()
    {
        int fac = (int)(Health / .2f);
        float rem = Health % .2f;
        for(int x = 0;x<fac;x++)
        {
            heartCntr[x].sprite = heartFull;
        }

        if (Health < .9f&&Health>0)
        {
            if (fac < 5)
                for (int x = fac; x < 5; x++)
                {
                    if (rem > .05f && rem < .1f)
                        heartCntr[fac].sprite = heartHalf;
                    else
                        heartCntr[x].sprite = heartEmpty;
                }
        }
    }
}
