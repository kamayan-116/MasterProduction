using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationCtrl : MonoBehaviour
{
    Animator animCtrl;
    private float probabNum;  // 耐える時の乱数
    public bool isCollision = false;  // 衝突したらtrue
    private bool isDecTime = false;  // 耐えてるアニメーションの時true
    private bool isEndureFront;  // 前に耐えてる時true、後ろに耐えてる時false
    private float endureTimeMag;  // 時間によって耐える確率の倍数
    private float powerEndure = 0;  // 力による耐えれない確率
    private float endureProb = 1f;  // 耐える確率
    private int endureHit = 0;  // 復活するために押した回数
    [SerializeField] private BoxCollider handcollider;
    [SerializeField] SliderCtrl sliderCtrl;
    [SerializeField] EndureSliderCtrl endureSliderCtrl;
    [SerializeField] UICtrl uiCtrl;
    [SerializeField] private GameCtrl gameCtrl;
    
    // Start is called before the first frame update
    void Start()
    {
        animCtrl = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDecTime)
        {
            endureProb -= Time.deltaTime * endureTimeMag;
        }

        endureSliderCtrl.EndureMove(endureProb);

        animCtrl.SetFloat("Endure", endureProb);
    }

    // Collisionの消去
    private void HideCollision()
    {
        handcollider.enabled = false;
    }

    // Collisionの復活
    public void AppearCollision()
    {
        handcollider.enabled = true;
    }

    // 下に避けるアニメーションの再生
    public void DownStart()
    {
        animCtrl.SetBool("Down", true);
    }

    // 下に避けたとこから戻るアニメーションの再生
    public void DownBack()
    {
        animCtrl.SetBool("Down", false);
    }

    // 右に避けるアニメーションの再生
    public void RightStart()
    {
        animCtrl.SetBool("Right", true);
    }

    // 右に避けたとこから戻るアニメーションの再生
    public void RightBack()
    {
        animCtrl.SetBool("Right", false);
    }

    // 左に避けるアニメーションの再生
    public void LeftStart()
    {
        animCtrl.SetBool("Left", true);
    }

    // 左に避けたとこから戻るアニメーションの再生
    public void LeftBack()
    {
        animCtrl.SetBool("Left", false);
    }

    // 上に避けるアニメーションの再生
    public void UpStart()
    {
        animCtrl.SetBool("Up", true);
    }

    // 上に避けたとこから戻るアニメーションの再生
    public void UpBack()
    {
        animCtrl.SetBool("Up", false);
    }

    // 前に押すアニメーションの再生
    public void PushStart()
    {
        animCtrl.SetBool("Push", true);
        StartCoroutine("PushBack");
    }

    // 押したとこから戻るアニメーションの再生
    private IEnumerator PushBack()
    {
        yield return new WaitForSeconds(0.5f);
        animCtrl.SetBool("Push", false);
    }

    // 避けられた時の自分の力による耐える確率の計算
    public void PushEndure(float fpower)
    {
        endureProb = 1f;
        powerEndure = fpower - 0.5f;
        if(powerEndure < 0)
        {
            powerEndure = 0;
        }
        endureProb -= powerEndure;
    }

    // 衝突時相手の力を受けた時の耐える確率の計算
    public void ReceiveEndure(float fpower)
    {
        if(fpower <= 0)
        {
            StartCoroutine("PushBack");
        }
        else
        {
            PinchBack();
        }
        endureProb = 1f;
        powerEndure = fpower * 0.75f;
        endureProb -= powerEndure;
    }

    // 前にPinchになるかを判定する関数
    public void CollisionCheck()
    {
        if(powerEndure > 0 && !isCollision)
        {
            PinchFront();
            isEndureFront = true;
        }

    }

    // 前のPinchのアニメーションの再生
    public void PinchFront()
    {
        animCtrl.SetBool("PinchF", true);
    }

    // 後ろのPinchのアニメーションの再生
    public void PinchBack()
    {
        animCtrl.SetBool("PinchB", true);
        isCollision = true;
        isEndureFront = false;
    }

    // 耐えるアニメーションが始まった際に呼ばれる関数
    public void StartEndure(float fendureMag)
    {
        isDecTime = true;
        endureTimeMag = fendureMag;
    }

    // 復活するために押した時に呼ばれる関数
    public void BackProbability(bool front)
    {
        if(isEndureFront != front) return;

        // 復活するために押した回数に応じて耐える確率が上昇
        endureProb += Mathf.Pow(2, endureHit) / 5000f;
        endureHit++;

        // 0~1の乱数を生成し耐える確率より小さければ復活
        probabNum = Random.value;
        if(probabNum < endureProb)
        {
            if(isEndureFront)
            {
                animCtrl.SetBool("PinchF", false);
            }
            else
            {
                animCtrl.SetBool("PinchB", false);
            }
        }
    }

    // 倒れた時に呼ばれる関数＝勝敗が決着
    private void Lose()
    {
        uiCtrl.PlayEnd(this.gameObject.name);
        gameCtrl.ChangeState(GameCtrl.GameState.CLEAR);
    }

    // 耐える確率の初期化
    public void EndureInitialize()
    {
        isDecTime = false;
        isCollision = false;
        endureProb = 1f;
        endureHit = 0;
    }

    // PowerSliderの初期化
    public void SliderInitialize()
    {
        sliderCtrl.ValueInitialize();
    }

    // 再度プレイする際に呼ばれる関数
    public void AnimationInitialize()
    {
        animCtrl.SetBool("Initialize", true);
        animCtrl.SetBool("PinchF", false);
        animCtrl.SetBool("PinchB", false);
    }

    // Idle状態で呼ばれる関数（初期化のParameterをoffにするため）
    public void IdleStart()
    {
        animCtrl.SetBool("Initialize", false);
    }
}
