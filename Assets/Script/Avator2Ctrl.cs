using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avator2Ctrl : MonoBehaviour
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
        
        if(Input.GetKey(KeyCode.K))
        {
            animationCtrl.DownStart();
        }

        if(Input.GetKeyUp(KeyCode.K))
        {
            animationCtrl.DownBack();
        }

        if(Input.GetKey(KeyCode.L))
        {
            animationCtrl.RightStart();
        }

        if(Input.GetKeyUp(KeyCode.L))
        {
            animationCtrl.RightBack();
        }

        if(Input.GetKey(KeyCode.J))
        {
            animationCtrl.LeftStart();
        }

        if(Input.GetKeyUp(KeyCode.J))
        {
            animationCtrl.LeftBack();
        }

        if(Input.GetKey(KeyCode.I))
        {
            animationCtrl.UpStart();
        }

        if(Input.GetKeyUp(KeyCode.I))
        {
            animationCtrl.UpBack();
        }

        if(Input.GetKey(KeyCode.N))
        {
            sliderCtrl.IncSlider();
        }

        if(Input.GetKeyUp(KeyCode.N))
        {
            animationCtrl.PushStart();
            sliderCtrl.GoPush();
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            animationCtrl.BackProbability(true);
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            animationCtrl.BackProbability(false);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            sliderCtrl.CollisionPush();
        }
    }
}
