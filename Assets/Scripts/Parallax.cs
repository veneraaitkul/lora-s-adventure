using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    [SerializeField]
    private GameObject Camera;
    [SerializeField]
    private float ParallaxValue;
    private Vector3 oldPosition, newPosition;
    

	// Use this for initialization
	void Start () {
        oldPosition = Camera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //createParralax();
        //oldPosition = Camera.transform.position;
    }

    private void createParralax()
    {
        Vector3 movedPosition;

        newPosition = Camera.transform.position;

        print("old position: " + oldPosition.y);
        print("new position: " + newPosition.y);

        
        if (newPosition.y > oldPosition.y)
        {
            movedPosition = this.transform.position;
            movedPosition.y += ParallaxValue;
            this.transform.position = movedPosition;

        }

        else if (newPosition.y < oldPosition.y)
        {
            movedPosition = this.transform.position;
            movedPosition.y -= ParallaxValue;
            this.transform.position = movedPosition;
        }

        
    }
}
