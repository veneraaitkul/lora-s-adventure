using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    [SerializeField]    
    private GameObject[] Enemies;
    [SerializeField]
    private GameObject StartUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) startGame();
    }

    public void findEnemies()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void endGame()
    {
        //stop enemies
        for (int x = 0; x < Enemies.Length; x++)
        {
            Enemies[x].GetComponent<EnemyMovement>().HorizontalSpeed = 0;
            Enemies[x].GetComponent<Animator>().speed = 0;
        }

        //stop player
        GameObject.FindGameObjectWithTag("Player").GetComponent<movementPlayer>().KillPlayer();

        //stop music
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        //play death music
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();

        //change UI
        GameObject.Find("UI").GetComponent<manageUI>().SetGameOver();

    }

    public void startGame()
    {
        StartUI.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.4f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<movementPlayer>().alive = true;
    }

    



}
