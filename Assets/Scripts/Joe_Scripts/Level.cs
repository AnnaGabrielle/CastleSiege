using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] int breakableBricks;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void countBreakableBricks()
    {
        breakableBricks++;
    }

    public void BrickDestroyed()
    {
        breakableBricks--;
        if (breakableBricks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
