using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class portalgun : MonoBehaviour
{
    Color color;
    GameObject current;
    [SerializeField]
    GameObject Portal;
    [SerializeField]
    LineRenderer line;
    [SerializeField]
    GameObject player;
    [SerializeField]
    LayerMask layer;
    [SerializeField]
    GameObject tip;

    private void Awake()
    {
        current = null;
    }
    private void Update()
    {
        Vector3 aimdirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position).normalized;
        float angle = Mathf.Atan2(aimdirection.y, aimdirection.x) * Mathf.Rad2Deg;
        transform.parent.eulerAngles = new Vector3(0, 0, angle);
        line.SetPosition(0,tip.transform.position);
        line.SetPosition(1, Physics2D.Raycast(origin: gameObject.transform.parent.position, direction: gameObject.transform.right, distance: 1000,layer).point);
        if (Input.GetButtonDown("Fire1")) 
        {
            RaycastHit2D hit = Physics2D.Raycast(origin:gameObject.transform.parent.position,direction:gameObject.transform.right,distance:Mathf.Infinity,layerMask:LayerMask.GetMask("ground"));
            if(hit != null && hit.collider != null) 
            {
                if(current== null) 
                {
                    current = GameObject.Instantiate(Portal);
                    current.transform.GetChild(0).transform.position = hit.point;
                    current.transform.GetChild(0).rotation = Quaternion.FromToRotation(Vector2.right, hit.normal);
                    color = Random.ColorHSV();
                    color.a = 0.5f;
                    current.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
                }
                else 
                {
                    current.transform.GetChild(1).gameObject.SetActive(true);
                    current.transform.GetChild(1).transform.position = hit.point;
                    current.transform.GetChild(1).rotation = Quaternion.FromToRotation(Vector2.right, hit.normal);
                    current.GetComponent<portalparent>().activated= true;
                    color.a = 1;
                    current.transform.GetChild(1).GetComponent<SpriteRenderer>().color = color;
                    current.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
                    current = null;
                }
            }    
           
        }
    }
}
