using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySample : MonoBehaviour
{
    [SerializeField] private SliderCtrl sliderCtrl;
    [SerializeField] private MoveCtrl moveCtrl;
    [SerializeField] private GameCtrl gameCtrl;
    [SerializeField] private float interval;
    [SerializeField] private float fTime;
    private int iProbabNum;
    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        iProbabNum = Random.Range(76, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameCtrl.gameState != GameCtrl.GameState.PLAY) return;

        fTime += Time.deltaTime;

        if(fTime > interval && !moveCtrl.isCollision)
        {
            iProbabNum = Random.Range(1, 100);
            Action(iProbabNum);
            fTime = 0;
        }
        
        if(iProbabNum <= 70)
        {
            sliderCtrl.DecSlider();
        }
        else
        {
            sliderCtrl.IncSlider();
        }
    }

    private IEnumerator MoveLeft()
    {
        moveCtrl.MoveRight();
        yield return new WaitForSeconds(0.5f);
        moveCtrl.MoveLeft();
    }

    private IEnumerator MoveRight()
    {
        moveCtrl.MoveLeft();
        yield return new WaitForSeconds(0.5f);
        moveCtrl.MoveRight();
    }

    private IEnumerator MoveUp()
    {
        moveCtrl.MoveUp();
        yield return new WaitForSeconds(0.5f);
        moveCtrl.MoveDown();   
    }

    private IEnumerator MoveDown()
    {
        moveCtrl.MoveDown();
        yield return new WaitForSeconds(0.5f);
        moveCtrl.MoveUp();
    }

    private void Action(int iNum)
    {
        if(iNum <= 10)
        {
            StartCoroutine("MoveLeft");
        }
        else if(iNum <= 20)
        {
            StartCoroutine("MoveRight");
        }
        else if(iNum <= 30)
        {
            StartCoroutine("MoveUp");
        }
        else if(iNum <= 40)
        {
            StartCoroutine("MoveDown");
        }
        else if(iProbabNum <= 65)
        {
            // sliderCtrl.GoPush();
        }

        // Debug.Log(iNum);
    }
}
