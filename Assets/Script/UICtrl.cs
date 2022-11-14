using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour
{
    [SerializeField] private GameCtrl gameCtrl;
    [SerializeField] private Text uiText;
    [SerializeField] private Button playButton;
    [SerializeField] private Text buttonText;
    [SerializeField] private AnimationCtrl player1AnimCtrl;
    [SerializeField] private AnimationCtrl player2AnimCtrl;


    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponentInChildren<Text>();
        playButton = GetComponentInChildren<Button>();
        buttonText = playButton.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Buttonのクリックにより呼ばれる
    public void PlayStart()
    {
        if(buttonText.text == "Play")
        {
            uiText.text = "のこった";
            StartCoroutine("UIFalse");
        }
        else if(buttonText.text == "Replay")
        {
            uiText.text = "はっけよい";
            buttonText.text = "Play";
            player1AnimCtrl.EndureInitialize();
            player1AnimCtrl.SliderInitialize();
            player1AnimCtrl.AnimationInitialize();
            player2AnimCtrl.EndureInitialize();
            player2AnimCtrl.SliderInitialize();
            player2AnimCtrl.AnimationInitialize();
        }
    }

    // 勝敗が決まると呼ばれる
    public void PlayEnd(string name)
    {
        this.gameObject.SetActive(true);
        uiText.text = name + "の負け";
        buttonText.text = "Replay";
    }

    private IEnumerator UIFalse()
    {
        yield return new WaitForSeconds(0.3f);
        gameCtrl.ChangeState(GameCtrl.GameState.PLAY);
        this.gameObject.SetActive(false);
    }
}
