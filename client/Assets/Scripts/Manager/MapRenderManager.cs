using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapRenderManager : MonoBehaviour{

    //���ΰ��� ��ġ�ְ�ޱ�, ���� �ý��۰��� �� ��ũ��Ʈ
    //�ʿ� ���� ���߷ε�, 
    private bool isPause;
    private bool isMainScene;
    private object escPanel;
    private Vector3 partnerLocation;
    private Vector3 myLocation;
    private Vector3 curMap;
    private HashSet<defaltMap> renderedScenes = new HashSet<defaltMap>();//�ִ� ������ �� �������ؾ���
    private int maxSceneCnt = 16; //��翡 ���� �޶��� �� ����
    private List< defaltMap> wholeMap;

    private void Awake() {
        //������ ���� �߰�����
    }

    // Update is called once per frame
    void Update() {
       
    }
    int[] delSceneList(int numOfMap) { // ������ �� ����Ʈ 
        int[] delMapList = new int[numOfMap];
        //ó������ �߰����� �߰����� �����ư�, ������ġ���� �� ������ ����
        return delMapList;
    }
    public defaltMap findMap(int mapCode) {
        defaltMap map = wholeMap.FirstOrDefault(map => map.mapNumber == mapCode);
        if (map != null) {
            throw new ArgumentException($"Map with mapNumber {mapCode} not found.");
        }
        return map;
    }
    public void makeMapData() { 
    }
    public void renderNewScenes(int[] mapNums, string[] mapName) {
        //���Ǽ���
        int cnt = mapNums.Length;
        if (renderedScenes.Count + cnt >= maxSceneCnt) {
            int[] sceneList = delSceneList(cnt);
            for (int i = 0; i < cnt; i++) {
                defaltMap tmp = findMap(sceneList[i]);
                defaltMap newMap = findMap(mapNums[i]);
                renderedScenes.Remove(tmp);
                SceneManager.UnloadSceneAsync(tmp.mapNumber);

                SceneManager.LoadScene(newMap.mapNumber, LoadSceneMode.Additive);
                newMap.renderTime = 0; 
                renderedScenes.Add(newMap);
            }
        }
    }
}
