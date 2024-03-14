using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumValue : MonoBehaviour {
    Slider volumSlider;
    public Slider master;
    public OptionCon option;
    public Text percent;
    public int number;
    public GetOption.Volum volumData;
    //public AudioSource audio;
    // Start is called before the first frame update
    void Start() {
        volumSlider = this.GetComponent<Slider>();
        switch (number) {
            case -1:
                volumData = option.Data.Volum.Master;
                break;
            case 0:
                volumData = option.Data.Volum.Bg;
                break;
            case 1: volumData = option.Data.Volum.Efx;
                break;
            default:
                break;
        };
         
        volumSlider.value = volumData.Value;
        percent.text = volumSlider.value + "%";
        ChangeValue();
    }

    public void ChangeValue() {
        volumData.Value = (int)volumSlider.value;
        percent.text = volumSlider.value + "%";
        option.ChangeVol(number);
    }
}