using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.Data;

public class GetOption : MonoBehaviour
{
    public OptionData optionData { get; set; }
    protected GameObject Root;
    private GameObject panel;
    public bool isPausing = false;
    private Stack<GameObject> Windows;

    [System.Serializable]
    public class VolumSettings {
        public Volum Master { get; set; }
        public Volum Bg { get; set; }
        public Volum Efx { get; set; }
    }

    [System.Serializable]
    public class Volum {
        public int Value { get; set; }
        public bool Muted { get; set; }
    }
    [System.Serializable]
    public class OptionData {
        public bool FullScreen { get; set; }
        public VolumSettings Volum { get; set; }
        public int[] Resolution { get; set; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBgm() { //bgm이 바뀔 경우
        VolumSettings vol = optionData.Volum;
        if (!(vol.Bg.Muted || vol.Master.Muted))
            this.transform.GetComponent<AudioSource>().volume = (float)vol.Bg.Value * vol.Master.Value / 10000;
    }
    public void ChangeEfx() { //Efx가 바뀔 경우 적용 후 효과음 출력
        VolumSettings vol = optionData.Volum;
        //if (!(vol.Bg.Muted || vol.Efx.Muted))
        //this.transform.GetComponent<AudioSource>().volume = (float)vol.Efx.Value * vol.Master.Value / 10000;
    }

    public void OpenOption() { //옵션열기
        GameObject OptionPanel = Resources.Load<GameObject>("Prefabs/OptionPanel");
        //isOption = true;
        Instantiate(OptionPanel, GameObject.Find("Game").transform);
    }
        public void DestroyPausePanel() {
        isPausing = false;
        Destroy(panel);
    }


    public void SaveOption() {
        string jsonFilePath = Path.Combine(Application.streamingAssetsPath, "UserData/Option.TXT");
        string json = JsonConvert.SerializeObject(optionData, Formatting.Indented);
        File.WriteAllText(jsonFilePath, json);
    }
}
