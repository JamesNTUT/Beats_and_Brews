using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public UnityEvent OnUse => throw new System.NotImplementedException();
    public static Item instance;

    public void Use()
    {
        Debug.Log("used record");
        Destroy(gameObject);
    }
}
