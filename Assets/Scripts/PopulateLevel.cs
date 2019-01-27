using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateLevel : MonoBehaviour {

    [SerializeField]
    [Tooltip("Number of platforms that will be generated on game start.")]
    private float NumberOfTotalPlatforms;

    [SerializeField]
    [Tooltip("Distance between created platforms.")]
    private float DistanceBetweenPlatform;

    [SerializeField]
    [Tooltip("Defines the minimum and maximum chance of enemy spawn.")]
    private float MinimumChanceOfEnemy, MaximumChanceOfEnemy;

    //prefabs
    [SerializeField]
    private GameObject Enemy, Floor;
    private GameObject EnemyList, FloorList;

	// Use this for initialization
	void Start () {

        EnemyList = GameObject.Find("Enemies");
        FloorList = GameObject.Find("Floors");

        PopulateFloors();
        PopulateEnemies();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //generate new floors at start 
    private void PopulateFloors()
    {
        for (int x = 1; x <= NumberOfTotalPlatforms; x++)
        {
            GameObject NewFloor = Instantiate(Floor,
                                              new Vector3(Mathf.Ceil(Random.Range(-10f, 6f)),
                                              (7f + x * DistanceBetweenPlatform)), Quaternion.Euler(Vector3.zero));
            //add to floor list
            NewFloor.transform.parent = FloorList.transform;
        }
    }

    //generate new floors at start 
    private void PopulateEnemies()
    {
        for (int x = 1; x <= NumberOfTotalPlatforms; x++)
        {
            //randomize chance to appear
            float chanceToAppear = Random.Range(0, 10);
            float percentageToAppear =  Mathf.Clamp(MinimumChanceOfEnemy + (x * 0.5f), 0, MaximumChanceOfEnemy);

            //randomize chance to begin rightwards
            float chanceToMoveRight = Random.Range(0, 2);

            //if appear, appear
            if (chanceToAppear < percentageToAppear)
            {
                GameObject NewEnemy = Instantiate(Enemy,
                                              new Vector3(Mathf.Ceil(Random.Range(-9f, 5f)),
                                               (4.5f + x * DistanceBetweenPlatform)), Quaternion.Euler(Vector3.zero));

                //if right, right
                if (Mathf.Round(chanceToMoveRight) >= 1) NewEnemy.GetComponent<EnemyMovement>().StartLeft = true;


                //add do enemy list
                NewEnemy.transform.parent = EnemyList.transform;
            }
                 
            
        }

        GameObject.Find("GameManager").GetComponent<Manager>().findEnemies();
    }
}
