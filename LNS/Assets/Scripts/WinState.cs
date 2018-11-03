using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour {

    public PlayerControl player; //player 
    public List<GameObject> finish; //finish list
    public GameObject instructions;
    public GameObject winText;
    public GameObject loseText;
    public GameObject winTextFinal;

    public GameState gameState = GameState.playing;
    public enum GameState
    {
        playing,
        win,
        lose
    }


    private void Update()
    {
        UpdateState();
        DisplayState();
    }

    private void UpdateState()
    {
        //see if finish is collected

        //just playing
        if (gameState == GameState.playing)
        {
            if (player.isDead)
            {
                gameState = GameState.lose;
            }
            if (player.BallsCollected >= finish.Count)
            {
                gameState = GameState.win;
            }
        }
        //win state
        else if (gameState == GameState.win)
        {
            //if press r, continue
            if (Input.GetKey(KeyCode.R))
            {
                //if it's not the last level, load next level
                if (SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                else //else, restart game
                    SceneManager.LoadScene(0);
            }
        }
        //lose state
        else if (gameState == GameState.lose)
        {
            try
            {
                Destroy(player.gameObject);
            }
            catch { }

            //if press r, restart level
            if (Input.GetKey(KeyCode.R))
            {
                //SceneManager.LoadScene(0);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void DisplayState()
    {
        //just playing
        if (gameState == GameState.playing)
        {
            instructions.SetActive(true);
            winText.SetActive(false);
            winTextFinal.SetActive(false);
            loseText.SetActive(false);
        }
        //win state
        else if (gameState == GameState.win)
        {
            //if it's not the last level, load normal winText
            if (SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
            {
                instructions.SetActive(false);
                winText.SetActive(true);
            }
            else //else load the final win text
            {
                instructions.SetActive(false);
                winTextFinal.SetActive(true);
            }
        }
        //lose state
        else if (gameState == GameState.lose)
        {
            instructions.SetActive(false);
            loseText.SetActive(true);
        }
    }
}
