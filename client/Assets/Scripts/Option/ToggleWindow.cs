using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleWindow : MonoBehaviour {
    public Toggle fullscreenToggle;
    private void Start() {
        // 현재 전체 화면 상태를 토글 버튼에 설정
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void ToggleFullscreen() {
        // 토글 버튼의 상태에 따라 전체 화면 설정 변경
        Screen.fullScreen = fullscreenToggle.isOn;
    }
}
