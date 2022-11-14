using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndureSliderCtrl : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // EndureProbabilityのSliderを変更
    public void EndureMove(float endure)
    {
        slider.value = endure;
    }
}
