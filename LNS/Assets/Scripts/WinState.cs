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
            try
            {
                //if press r, continue
                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            catch //will cause exception when reached max level, so restart game
            {
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

            //if press r, restart
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
            loseText.SetActive(false);
        }
        //win state
        else if (gameState == GameState.win)
        {
            instructions.SetActive(false);
            winText.SetActive(true);
        }
        //lose state
        else if (gameState == GameState.lose)
        {
            instructions.SetActive(false);
            loseText.SetActive(true);
        }
    }
}
