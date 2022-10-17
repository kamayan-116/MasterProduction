using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public enum PlayerState
    {
        Go,
        Right,
        Left,
        Back,
        NoMove
    };

    private PlayerState playerState = PlayerState.NoMove;
    [SerializeField] float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerState == PlayerState.Go)
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }

        if(playerState == PlayerState.Left)
        {
            // transform.position += transform.forward * Speed * Time.deltaTime;
            transform.position += -transform.right * Speed * Time.deltaTime;
        }

        if(playerState == PlayerState.Right)
        {
            // transform.position += transform.forward * Speed * Time.deltaTime;
            transform.position += transform.right * Speed * Time.deltaTime;
        }

        if(playerState == PlayerState.Back)
        {
            // transform.position += transform.forward * Speed * Time.deltaTime;
            transform.position += -transform.forward * Speed * Time.deltaTime;
        }
    }

    public void GoPushDown()
    {
        playerState = PlayerState.Go;
    }

    public void RightPushDown()
    {
        playerState = PlayerState.Right;
    }

    public void LeftPushDown()
    {
        playerState = PlayerState.Left;
    }

    public void BackPushDown()
    {
        playerState = PlayerState.Back;
    }

    public void PushUp()
    {
        playerState = PlayerState.NoMove;
    }
}
