using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masterVolum : MonoBehaviour
{
    public VolumValue[] volum= new VolumValue[2];
    public void ChangeVolum() {
        for (int i = 0; i < volum.Length; i++)
            volum[i].ChangeValue();
    }
}
