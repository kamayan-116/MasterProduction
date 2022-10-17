using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    [SerializeField] private SliderCtrl sliderCtrl;
    [SerializeField] private GameCtrl gameCtrl;
    [SerializeField] private UICtrl uICtrl;
    private Rigidbody rb;
    public bool isCollision;
    public bool isFall;
    private float power;
    private int direction;
    private float force;
    private Vector3 startPos;
    private Quaternion startQua;


    // Start is called before the first frame update
    void Start()
    {
        power = 0;
        isCollision = false;
        isFall = false;
        startPos = this.transform.position;
        if(startPos.x > 0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        startQua = this.transform.rotation;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        power = sliderCtrl.slider.value;

        if(this.rb.position.x != startPos.x && rb.velocity.magnitude <= 0f /*&& !isCollision*/)
        {
            BackTop();
        }

        if(this.rb.position.x < -0.5f || this.rb.position.x > 0.5f)
        {
            isFall = true;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }

        if(this.rb.rotation.eulerAngles.z <= 270f && this.rb.rotation.eulerAngles.z >= 90f)
        {
            gameCtrl.ChangeState(GameCtrl.GameState.CLEAR);
            uICtrl.PlayEnd(this.gameObject.name);
        }
    }

    public void MoveLeft()
    {
        rb.position -= new Vector3(0, 0, 1f);
    }

    public void MoveRight()
    {
        rb.position += new Vector3(0, 0, 1f);
    }

    public void MoveUp()
    {
        rb.position += new Vector3(0, 1f, 0);
    }

    public void MoveDown()
    {
        rb.position -= new Vector3(0, 1f, 0);
    }

    public void Push()
    {
        if(rb.position == startPos && power != 0)
        {
            rb.useGravity = true;
            force = power * direction * 6;
            rb.AddForce(new Vector3(force, 0, 0), ForceMode.Impulse);
        }
    }

    public void BackTop()
    {
        rb.position = startPos;
        rb.rotation = startQua;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        isFall = false;
        isCollision = false;
    }

    public void FrontAng()
    {
        if(this.rb.rotation.eulerAngles.z >= 270f)
        {
            rb.AddTorque(new Vector3(0, 0, 0.05f), ForceMode.Impulse);
            if(this.rb.rotation.eulerAngles.z <= 0)
            {
                rb.rotation = startQua;
                Debug.Log("okok");
            }
        }
    }

    public void BackAng()
    {
        if(this.rb.rotation.eulerAngles.z <= 90f)
        {
            rb.AddTorque(new Vector3(0, 0, -0.05f), ForceMode.Impulse);
            if(this.rb.rotation.eulerAngles.z <= 0)
            {
                rb.rotation = startQua;
                Debug.Log("okok");
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(gameObject.tag == "Player")
        {
            if(other.gameObject.tag == "Enemy")
            {
                isCollision = true;
                rb.useGravity = true;
            }
        }

        if(gameObject.tag == "Enemy")
        {
            if(other.gameObject.tag == "Player")
            {
                isCollision = true;
                rb.useGravity = true;
            }
        } 
    }
}
