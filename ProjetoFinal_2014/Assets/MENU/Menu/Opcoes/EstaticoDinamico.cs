using UnityEngine;
using System.Collections;
using System;

public class EstaticoDinamico : MonoBehaviour
{

    public GUITexture CheckBt;
    public Texture[] CheckBox;
    public static Boolean IsChecked;

    // Use this for initialization
    void Start()
    {
        CheckBt.guiTexture.enabled = true;
        CheckBt.guiTexture.texture = CheckBox[0];
        IsChecked = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (IsChecked == false)
        {
            CheckBt.guiTexture.texture = CheckBox[1];
            IsChecked = true;
            Debug.Log(IsChecked);
        }
        else if (IsChecked == true)
        {
            CheckBt.guiTexture.texture = CheckBox[0];
            IsChecked = false;
            Debug.Log(IsChecked);
        }
    }
}
