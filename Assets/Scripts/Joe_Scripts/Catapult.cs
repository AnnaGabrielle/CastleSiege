using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour {

    // configuration parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mousPosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 catapultPos = new Vector2(mousPosInUnits, transform.position.y);
        catapultPos.x = Mathf.Clamp(mousPosInUnits, minX, maxX);
        transform.position = catapultPos;
	}
}
