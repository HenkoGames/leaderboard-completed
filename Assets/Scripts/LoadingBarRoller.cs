using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadingBarRoller : MonoBehaviour
{
    private RectTransform image;
    public float rotationSpeed = 30;
    void Start()
    {
        image = GetComponent<RectTransform>(); 
    }

    void Update()
    {
        image.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }
}
