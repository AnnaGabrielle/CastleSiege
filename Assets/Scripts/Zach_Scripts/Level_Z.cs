using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Z : MonoBehaviour {

    // parameters
    [SerializeField] int breakableBlocks;  // Serialized for debugging purposes

    // cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }

}
