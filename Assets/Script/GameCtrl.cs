using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public enum GameState
    {
        TITLE,
        PLAY,
        CLEAR
    };

    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.TITLE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState(GameState nowState)
    {
        gameState = nowState;
    }
}
