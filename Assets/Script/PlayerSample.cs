using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSample : MonoBehaviour
{
    [SerializeField] private MoveCtrl moveCtrl;
    [SerializeField] private SliderCtrl sliderCtrl;
    [SerializeField] private GameCtrl gameCtrl;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gameCtrl.gameState != GameCtrl.GameState.PLAY) return;

        if(moveCtrl.isFall)
        {
            if(Input.GetKey(KeyCode.W))
            {
                moveCtrl.FrontAng();
            }

            if(Input.GetKey(KeyCode.S))
            {
                moveCtrl.BackAng();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                moveCtrl.MoveUp();
            }

            if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                moveCtrl.MoveDown();
            }

            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                moveCtrl.MoveLeft();
            }

            if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                moveCtrl.MoveRight();
            }
        }

        if(Input.GetMouseButton(0))
        {
            sliderCtrl.IncSlider();
        }
        else
        {
            sliderCtrl.DecSlider();
        }

        if(Input.GetMouseButtonDown(1))
        {
            sliderCtrl.GoPush();
        }
    }
}
