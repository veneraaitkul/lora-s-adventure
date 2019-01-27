using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    float HorizontalLimit;
    public float HorizontalSpeed;

    bool MoveLeft = true;
    [HideInInspector]
    public bool StartLeft = false;

	// Use this for initialization
	void Start () {
		if (StartLeft)
        {
            HorizontalSpeed = -HorizontalSpeed;
            flipObjectHorizontal();
        }
	}
	
	// Update is called once per frame
	void Update () {
        HandleDirectionChange();
        HandleMovement();
	}

    private void HandleDirectionChange()
    {
   
        if (Mathf.Abs(this.transform.position.x) > HorizontalLimit)
        { 
            MoveLeft = !MoveLeft;
            flipObjectHorizontal();
        }
    }

    private void HandleMovement()
    {
        Vector3 newPosition = this.transform.position;
        if (MoveLeft == true) newPosition.x -= HorizontalSpeed * Time.deltaTime;
        else newPosition.x += HorizontalSpeed * Time.deltaTime;

        this.transform.position = newPosition;
    }

    private void flipObjectHorizontal()
    {

        Vector3 OriginalLocalScale = this.transform.localScale;
        OriginalLocalScale.x *= -1;
        this.transform.localScale = OriginalLocalScale;

    }
}
