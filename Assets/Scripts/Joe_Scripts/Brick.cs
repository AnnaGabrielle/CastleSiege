using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject brickglitterEffects;

    Level level;
    GameSession gameStatus;
    private void Start()
    {
        level = FindObjectOfType<Level>();
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBrick();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level.countBreakableBricks();
        }
    }
    private void DestroyBrick()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        gameStatus.AddToScore();
        level.BrickDestroyed();
        TriggerglitterEffects();
    }

    private void TriggerglitterEffects()
    {
        GameObject glitter = Instantiate(brickglitterEffects, transform.position, transform.rotation);
        Destroy(glitter, 1f);
    }
}
