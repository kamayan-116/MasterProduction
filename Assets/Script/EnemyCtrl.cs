using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private AnimationCtrl animationCtrl;
    [SerializeField] private SliderCtrl sliderCtrl;
    private int iProbabNum;
    [SerializeField] private float fTime;
    [SerializeField] private float interval;
    

    // Start is called before the first frame update
    void Start()
    {
        iProbabNum = Random.Range(1, 100);
    }

    // Update is called once per frame
    void Update()
    {
        fTime += Time.deltaTime;

        if(fTime > interval)
        {
            iProbabNum = Random.Range(1, 100);
            Action(iProbabNum);
            fTime = 0;
        }

        if(iProbabNum <= 30)
        {
            sliderCtrl.IncSlider();
        }
        else
        {
            sliderCtrl.DecSlider();
        }
    }

    private void Action(int iNum)
    {
        if(iNum <= 20)
        {
            StartCoroutine("MoveLeft");
        }
        else if(iNum <= 40)
        {
            StartCoroutine("MoveRight");
        }
        else if(iNum <= 60)
        {
            StartCoroutine("MoveUp");
        }
        else if(iNum <= 80)
        {
            StartCoroutine("MoveDown");
        }
        else
        {
            StartCoroutine("Push");
        }

        // Debug.Log(iNum);
    }

    private IEnumerator MoveLeft()
    {
        animationCtrl.LeftStart();
        yield return new WaitForSeconds(0.5f);
        animationCtrl.LeftBack();
    }

    private IEnumerator MoveRight()
    {
        animationCtrl.RightStart();
        yield return new WaitForSeconds(0.5f);
        animationCtrl.RightBack();
    }

    private IEnumerator MoveUp()
    {
        animationCtrl.UpStart();
        yield return new WaitForSeconds(0.5f);
        animationCtrl.UpBack();
    }

    private IEnumerator MoveDown()
    {
        animationCtrl.DownStart();
        yield return new WaitForSeconds(0.5f);
        animationCtrl.DownBack();
    }

    private IEnumerator Push()
    {
        animationCtrl.PushStart();
        sliderCtrl.GoPush();
        yield return new WaitForSeconds(1f);
        //animationCtrl.PushBack();
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            animationCtrl.PinchBack();
            sliderCtrl.CollisionPush();
        }
    }
}
