using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.Data;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // 메인 게임매니저(게임 환경설정/ 현재씬 관리)와 분리 필요 
    string init = "{\"FullScreen\": true,\"Volum\": {\"Master\": {\"Value\": 80,\"Muted\": false},\"Bg\": {\"Value\": 90,\"Muted\": false},\"Efx\": {\"Value\": 80,\"Muted\": false}},\"Resolution\": [1920,1080]}}";
    string userSaveData = Path.Combine(Application.streamingAssetsPath, "UserData/SaveData.txt");
    string curMainScene= "MainMenu";

    private GameObject panel;
    protected AudioSource BgmAudioSource;
    protected GameObject pausePanel;
    public bool isPausing = false;
    public bool isOption = false;
    public bool debugmode;
    public OptionData optionData { get; set; }
    protected GameObject Root;
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
    public void Start() {
        BgmAudioSource = this.transform.GetComponent<AudioSource>();
        Root = GameObject.Find("Canvas");
        if (!debugmode) {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }
        string jsonFilePath = Path.Combine(Application.streamingAssetsPath, "UserData/Option.TXT");
        StartCoroutine(LoadJsonData(jsonFilePath));

    }
    IEnumerator LoadJsonData(string jsonFilePath) {
        if (!File.Exists(jsonFilePath)) {
            optionData = JsonConvert.DeserializeObject<OptionData>(init);
        }
        else
            using (UnityWebRequest www = UnityWebRequest.Get(jsonFilePath)) {
            yield return www.SendWebRequest();
                string json = www.downloadHandler.text;
                optionData = JsonConvert.DeserializeObject<OptionData>(json);
            
        }
        VolumSettings vol = optionData.Volum;
        if (!(vol.Bg.Muted || vol.Master.Muted))
           BgmAudioSource.volume = (float)vol.Bg.Value * vol.Master.Value / 10000;
        else
            BgmAudioSource.volume = 0;
    }

    protected virtual void Awake() {
        Root = GameObject.Find("Game");
        pausePanel = Resources.Load<GameObject>("Prefabs/Pause");
    }
    protected virtual void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if (isOption)
                FindObjectOfType<OptionCon>().CloseOption();
            else if (isPausing)
                DestroyPausePanel();
            else
                ShowPausePanel();
        }
    }

    public void OpenOption() { //옵션열기
        GameObject OptionPanel = Resources.Load<GameObject>("Prefabs/OptionPanel");
        isOption = true;
        Instantiate(OptionPanel,Root.transform);
    }

    void ShowPausePanel() {
        Debug.Log("퍼즈 확인");
        isPausing = true;
        panel = Instantiate(pausePanel, Root.transform);
        // Add logic to show the pause panel and handle pausing the game
    }

    public void DestroyPausePanel() {
        isPausing = false;
        Destroy(panel);
    }
    public void ChangeBgm() { //bgm이 바뀔 경우
        VolumSettings vol = optionData.Volum;
        if (!(vol.Bg.Muted || vol.Master.Muted))
            BgmAudioSource.volume = (float)vol.Bg.Value * vol.Master.Value / 10000;
    }
    public void ChangeEfx() { //Efx가 바뀔 경우 적용 후 효과음 출력
        VolumSettings vol = optionData.Volum;
        //if (!(vol.Bg.Muted || vol.Efx.Muted))
        //this.transform.GetComponent<AudioSource>().volume = (float)vol.Efx.Value * vol.Master.Value / 10000;
    }

    public void ChangeMainScene(string SceneName) {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        SceneManager.UnloadScene(curMainScene);
        curMainScene = SceneName;
    }
    public void SaveOption() {
        string jsonFilePath = Path.Combine(Application.streamingAssetsPath, "UserData/Option.TXT");
        string json = JsonConvert.SerializeObject(optionData, Formatting.Indented);
        File.WriteAllText(jsonFilePath, json);
    }
    public void ChangeBgm(AudioClip clip) {
        BgmAudioSource.clip = clip;
        BgmAudioSource.Play();
    }
}
