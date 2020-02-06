using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptSceneSwitch : MonoBehaviour
{
    public void fncSwitchScene(int getInd)
    {
        SceneManager.LoadScene(getInd);
    }
}
