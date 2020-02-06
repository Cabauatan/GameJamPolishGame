using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveScriptable", menuName = "ggj/WaveScriptable", order = 0)]
public class WaveScriptable : ScriptableObject 
{
    public int num_of_enemies;
    public RefugeeMovement refugee;
    public float spawnRate;
}

