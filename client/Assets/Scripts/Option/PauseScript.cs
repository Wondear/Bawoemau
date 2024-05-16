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

    public void OpenMenual() { //���� ���� ����

    }
    public void Countinued() {//���� �簳
        defaltEventComponent.DestroyPausePanel();
    }

    public void OpenOption() { //�ɼǿ���
        defaltEventComponent.OpenOption();
    }

    public void GameOff() { //
        GameObject ClosePanel = Resources.Load<GameObject>("Prefabs/BoolPanel");
        ClosePanel.transform.Find("Yes").GetComponent<Button>().onClick.AddListener(() => {
            Application.Quit();
        });
        ClosePanel.GetComponentsInChildren<TextMeshProUGUI>()[0].text = "��������";
        ClosePanel.GetComponentsInChildren<TextMeshProUGUI>()[1].text = "�ش����� ����� ������� �ʽ��ϴ�. �����Ͻðڽ��ϱ�?";
        Instantiate(ClosePanel, GameObject.Find("Game").transform);
    }
}
