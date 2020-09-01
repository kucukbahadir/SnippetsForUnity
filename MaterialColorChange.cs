using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorChange : MonoBehaviour
{
    private int differentColors = 5;
    public Material[] materialList = new Material[5]; // differentColors
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }


    public void ChangeColorMaterial() {
        
        int selectColor  = Random.Range(0, differentColors);

        rend.sharedMaterial = materialList[selectColor];

    }
}
