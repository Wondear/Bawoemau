using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //���ΰ��� ��ġ�ְ�ޱ�, ���� �ý��۰��� �� ��ũ��Ʈ
    //�ʿ� ���� ���߷ε�, 

    private bool isPause;
    private bool partnerLocation;
    private List<int> renderedScenes = new List<int>();//�ִ� ������ �� �������ؾ���
    private int maxSceneCnt = 16; //��翡 ���� �޶��� �� ����
    private defaltMaps[] wholeMap;

    void Start()
    {
        //������ ���� �߰�����
        wholeMap = new defaltMaps[64];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int[] delSceneList(int numOfMap) { // ������ �� ����Ʈ 
        int[] delMapList = new int[numOfMap];
        //ó������ �߰����� �߰����� �����ư�, ������ġ���� �� ������ ����
        
        return delMapList;
    }
    void renderNewScenes(int[] mapNums) {
        //���Ǽ���
        int cnt = mapNums.Length;
        if (renderedScenes.Count + cnt >= maxSceneCnt) {
            int[] sceneList = delSceneList(cnt);
            for (int i = 0; i < cnt; i++) {
                int tmp = sceneList[i];
                renderedScenes.Remove(tmp);
                SceneManager.UnloadSceneAsync(tmp);
            }
        }
        for (int i = 0; i < cnt; i++) {

        }

    }
}
