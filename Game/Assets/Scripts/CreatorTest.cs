using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class CreatorTest : MonoBehaviour
{
    public GameObject prefab1;
    public Transform pos;
    public GameObject canvas;
    void Start()
    {
        GameObject go = Instantiate(prefab1, pos);
        go.transform.SetParent(canvas.transform, false);
    }
}
