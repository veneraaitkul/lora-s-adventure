using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class manageUI : MonoBehaviour {

    [SerializeField]
    private Text gameText;

    [SerializeField]
    private GameObject player, EndText, EndBackgroundImage;
    private Text EndGameText;
    private movementPlayer movementPlayer;
    private bool GameOver = false;

	// Use this for initialization
	void Start () {
        EndGameText = EndText.GetComponent<Text>();
        movementPlayer = player.GetComponent<movementPlayer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameOver)
        {
            if (Input.GetKey("r"))
            {
                print("reset?");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }

        else
        {
            //ManageDebugText();
        }

        

    }

    public void SetGameOver()
    {
        GameOver = true;
        EndText.SetActive(true);
        EndBackgroundImage.SetActive(true);

        EndGameText.text += "Pontos: " + player.GetComponent<movementPlayer>().points;
        EndGameText.text += "\n\nPressione R para Recomeçar";


        gameText.text = "";
    }

    void ManageDebugText()
    {
        string DebugText = "Points: " + movementPlayer.points + "\n";

        DebugText += "Time to Change: " + ((Mathf.Round((movementPlayer.TimeToChangeGravity - Time.time) * 100f) / 100f)).ToString() + "\n";
        
        if (player.GetComponent<Rigidbody2D>().gravityScale < 0)
        {
            DebugText += "Pulling UP\n";
        }

        else
        {
            DebugText += "Pulling DOWN\n";
        }


        gameText.text = DebugText;
    }
}
