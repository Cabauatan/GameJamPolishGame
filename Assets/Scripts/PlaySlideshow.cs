using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
public class PlaySlideshow : MonoBehaviour
{
   public List<Sprite> pictures;
   public scriptSceneSwitch switchScene;
   public Image image;
    void Start()
    {
        StartCoroutine(play());
    }

    // Update is called once per frame
    IEnumerator play() {
        for(int i = 0; i < pictures.Count; i++)
        {
            image.overrideSprite = pictures[i];
            if(i==pictures.Count-1)
            {
                yield return new WaitForSeconds(3.0f);
                switchScene.fncSwitchScene(2);
            }
            else
            yield return new WaitForSeconds(3.0f);
            
        }
        //CHANGE SCENE
        
    }
}
