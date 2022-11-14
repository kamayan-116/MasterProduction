using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCtrl : MonoBehaviour
{
    public Slider slider;
    [SerializeField] AnimationCtrl animationCtrl;
    [SerializeField] AnimationCtrl opponentCtrl;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // PowerのSliderを溜める
    public void IncSlider()
    {
        slider.value += Time.deltaTime * 0.2f;
        // slider.value += Time.deltaTime;
    }

    public void DecSlider()
    {
        slider.value -= Time.deltaTime * 0.02f;
    }

    // Pushすると呼ばれる
    public void GoPush()
    {
        animationCtrl.PushEndure(slider.value);
    }

    // 互いに衝突すると呼ばれる
    public void CollisionPush()
    {
        opponentCtrl.ReceiveEndure(slider.value);
    }

    // PowerのSliderの初期化
    public void ValueInitialize()
    {
        slider.value = 0;
    }
}
