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

    public void PlayStart()
    {
        uiText.text = "のこった";
        StartCoroutine("UIFalse");
    }

    public void PlayEnd(string name)
    {
        uiText.text = name + "の負け";
        buttonText.text = "Replay";
        this.gameObject.SetActive(true);
    }

    private IEnumerator UIFalse()
    {
        yield return new WaitForSeconds(0.3f);
        gameCtrl.ChangeState(GameCtrl.GameState.PLAY);
        this.gameObject.SetActive(false);
    }
}
