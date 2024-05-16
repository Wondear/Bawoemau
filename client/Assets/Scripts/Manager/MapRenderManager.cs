using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapRenderManager : MonoBehaviour{

    //서로간의 위치주고받기, 게임 시스템관리 할 스크립트
    //맵에 대한 다중로드, 
    private bool isPause;
    private bool isMainScene;
    private object escPanel;
    private Vector3 partnerLocation;
    private Vector3 myLocation;
    private Vector3 curMap;
    private HashSet<defaltMap> renderedScenes = new HashSet<defaltMap>();//최대 랜더링 씬 개수정해야함
    private int maxSceneCnt = 16; //사양에 따라 달라질 수 있음
    private List< defaltMap> wholeMap;

    private void Awake() {
        //맵정보 엑셀 추가예정
    }

    // Update is called once per frame
    void Update() {
       
    }
    int[] delSceneList(int numOfMap) { // 삭제할 신 리스트 
        int[] delMapList = new int[numOfMap];
        //처리로직 추가예정 추가된지 오래됐고, 현재위치에서 먼 순서로 삭제
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
        //조건설정
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
