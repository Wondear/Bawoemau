using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleWindow : MonoBehaviour {
    public Toggle fullscreenToggle;
    private void Start() {
        // ���� ��ü ȭ�� ���¸� ��� ��ư�� ����
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void ToggleFullscreen() {
        // ��� ��ư�� ���¿� ���� ��ü ȭ�� ���� ����
        Screen.fullScreen = fullscreenToggle.isOn;
    }
}
