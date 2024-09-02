using UnityEngine;

public class GroundPanelLvl : UIWrapper
{
    [Header("Исп.скрипт")]
    [SerializeField] private SceneWrapper executorSwithScene;
    [Header("Панели")]
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject groundPanel;
    [SerializeField] private GameObject loadPanel;
    [SerializeField] private GameObject settingsPanel;
    [Header("Кнопки")]
    [SerializeField] private CustomButtons retenGameButton;
    [SerializeField] private CustomButtons loadButton;
    [SerializeField] private CustomButtons settingButton;
    [SerializeField] private CustomButtons exitMainMenuButton;
    [Header("Аним Кнопки")]
    [SerializeField][Range(0.1f, 5f)] private float scaleButton;
    [SerializeField][Range(0.1f, 3f)] private float durationButton;
    [Header("Аним Панель")]
    [SerializeField] private Transform pointTypaDefault;
    [SerializeField] private Transform pointTypaCloseGamePanel;
    [SerializeField] private Transform pointTypaCloseGroundPanel;
    [SerializeField] private Transform pointTypaClosePanels;
    [SerializeField][Range(0.1f, 3f)] private float durationPanel;

}

