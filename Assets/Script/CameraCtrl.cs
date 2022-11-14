using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask layerMask;

    private Vector3 difference;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // カメラの座標からRayを飛ばして当たったオブジェクトのMaterialを透過
        difference = player.transform.position - this.transform.position;
        direction = difference.normalized;
        Ray ray = new Ray(this.transform.position, direction);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, difference.magnitude, layerMask))
        {
            if(hit.collider.gameObject != player)
            {
                SkinnedMeshRenderer playerRenderer = hit.collider.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
                playerRenderer.material.color = new Color32(255, 255, 255, 128);
            } 
        }
    }
}
