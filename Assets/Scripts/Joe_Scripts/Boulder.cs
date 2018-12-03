using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{

    // config params
    [SerializeField] Catapult catapult;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] boulderSounds;

    // state
    Vector2 catapultToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;


    // Use this for initialization
    void Start()
    {
        catapultToBallVector = transform.position - catapult.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBoulderToCatapult();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBoulderToCatapult()
    {
        Vector2 catapultPos = new Vector2(catapult.transform.position.x, catapult.transform.position.y);
        transform.position = catapultPos + catapultToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = boulderSounds[Random.Range(0, boulderSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
