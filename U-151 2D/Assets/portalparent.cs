using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class portalparent : MonoBehaviour
{
    public bool activated;
    public Dictionary<GameObject,GameObject> tagged;
    private void Awake()
    {
        activated= false;
        tagged = new Dictionary<GameObject, GameObject>();
    }
}
