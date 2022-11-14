using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatorCtrl : MonoBehaviour
{
    [SerializeField] private AnimationCtrl animationCtrl;
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
        
        if(Input.GetKey(KeyCode.S))
        {
            animationCtrl.DownStart();
        }

        if(Input.GetKeyUp(KeyCode.S))
        {
            animationCtrl.DownBack();
        }

        if(Input.GetKey(KeyCode.D))
        {
            animationCtrl.RightStart();
        }

        if(Input.GetKeyUp(KeyCode.D))
        {
            animationCtrl.RightBack();
        }

        if(Input.GetKey(KeyCode.A))
        {
            animationCtrl.LeftStart();
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            animationCtrl.LeftBack();
        }

        if(Input.GetKey(KeyCode.W))
        {
            animationCtrl.UpStart();
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            animationCtrl.UpBack();
        }

        if(Input.GetKey(KeyCode.C))
        {
            sliderCtrl.IncSlider();
        }

        if(Input.GetKeyUp(KeyCode.C))
        {
            animationCtrl.PushStart();
            sliderCtrl.GoPush();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            animationCtrl.BackProbability(true);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            animationCtrl.BackProbability(false);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player2")
        {
            sliderCtrl.CollisionPush();
        }
    }
}
