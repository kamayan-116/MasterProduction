using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCtrl : MonoBehaviour
{
    public Slider slider;
    [SerializeField] MoveCtrl moveCtrl;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncSlider()
    {
        slider.value += Time.deltaTime * 0.3f;
        // slider.value += Time.deltaTime;
    }

    public void DecSlider()
    {
        slider.value -= Time.deltaTime * 0.02f;
    }

    public void GoPush()
    {
        slider.value = 0;
        moveCtrl.Push();
    }
}
