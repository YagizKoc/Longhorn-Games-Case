using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }
    public event Action objectsMatched;
    public void ObjectsMatched() {

        if (objectsMatched != null) {
        
            objectsMatched();
        }
    }
}
