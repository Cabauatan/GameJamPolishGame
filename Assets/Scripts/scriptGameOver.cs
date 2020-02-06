using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void fncEndGame(int x)
    {
        Time.timeScale=1;
        SceneManager.LoadScene(x);
        }
}
