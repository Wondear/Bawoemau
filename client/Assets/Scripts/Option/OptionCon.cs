using UnityEngine;
using UnityEditor;

public class OptionCon : MonoBehaviour {
    public GameObject OptionMenu;
    public int[] Volums; //= new int[3];
    public int MasterVolum, BackVolum, EfxVolum;
    GameManager Options;
    public GameManager.OptionData Data;
    // Start is called before the first frame update
    private void Awake() {
        Options = FindObjectOfType<GameManager>();
        Data = Options.GetComponent<GameManager>().optionData;
        OptionMenu = Resources.Load<GameObject>("Prefabs/OptionPanel");


    }
    public void ChangeVol(int num) {
        if (num == 1)
            Options.ChangeEfx();
        else
            Options.ChangeBgm();
    }

    public void CloseOption() {
        //�ɼ��� ������, �� �ٸ� ��ü�鿡�� �����ؾ���  
        OptionMenu = GameObject.Find("Option Panel");
        //PrefabUtility.ApplyPrefabInstance(prefabSource, InteractionMode.AutomatedAction);
        //FindObjectOfType<GetOption>().isOption = false;
        Options.SaveOption();
        Destroy(this.gameObject);
    }

}
