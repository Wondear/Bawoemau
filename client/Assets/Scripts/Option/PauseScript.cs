using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
    Canvas canvas;
    GameManager defaltEventComponent;
    // Start is called before the first frame update
    void Start() {
        this.transform.GetComponent<Canvas>();
        defaltEventComponent = FindObjectOfType<GameManager>();
    }

    public void OpenMenual() { //게임 설명 열기

    }
    public void Countinued() {//게임 재개
        defaltEventComponent.DestroyPausePanel();
    }

    public void OpenOption() { //옵션열기
        defaltEventComponent.OpenOption();
    }

    public void GameOff() { //
        GameObject ClosePanel = Resources.Load<GameObject>("Prefabs/BoolPanel");
        ClosePanel.transform.Find("Yes").GetComponent<Button>().onClick.AddListener(() => {
            Application.Quit();
        });
        ClosePanel.GetComponentsInChildren<TextMeshProUGUI>()[0].text = "게임종료";
        ClosePanel.GetComponentsInChildren<TextMeshProUGUI>()[1].text = "해당일의 결과는 저장되지 않습니다. 종료하시겠습니까?";
        Instantiate(ClosePanel, GameObject.Find("Game").transform);
    }
}
