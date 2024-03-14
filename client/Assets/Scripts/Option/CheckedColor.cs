using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckedColor : MonoBehaviour {
    public Toggle toggle;
    public Image bakcground;
    public Color onColor;
    public Color offColor;
    public void Start() {
            toggleColor();
    }
    public void toggleColor(){
        if (toggle.isOn) 

            bakcground.color = onColor;
        else bakcground.color = offColor;
    }
}
