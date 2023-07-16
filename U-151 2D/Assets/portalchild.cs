using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class portalchild : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "noportal")
        {
            if (GetComponentInParent<portalparent>().activated)
            {
                if (!GetComponentInParent<portalparent>().tagged.ContainsKey(collision.gameObject))
                {
                    GetComponentInParent<portalparent>().tagged.Add(collision.gameObject, gameObject);
                    collision.gameObject.transform.position = gameObject.transform.parent.GetChild(gameObject.transform.GetSiblingIndex() == 1 ? 0 : 1).transform.position;
                    Vector2 temp = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.parent.GetChild(gameObject.transform.GetSiblingIndex() == 1 ? 0 : 1).right * temp.magnitude;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "noportal")
        {
            if (GetComponentInParent<portalparent>().activated)
            {
                if (GetComponentInParent<portalparent>().tagged[collision.gameObject] != gameObject)
                {
                    GetComponentInParent<portalparent>().tagged.Remove(collision.gameObject);
                }
            }
        }
    }
}
