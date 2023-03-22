using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class WinMenu : MonoBehaviour
{
    [SerializeField]
    private UIDocument doc;

    VisualElement root;

    private Button StartButton;
    private Button ExitButton;

    void Start()
    {
        root = doc.rootVisualElement;
        StartButton = root.Q<Button>("StartButton");
        ExitButton = root.Q<Button>("ExitButton");

        StartButton.clickable.clicked += StartButtonClicked;
        ExitButton.clickable.clicked += ExitButtonClicked;

        void StartButtonClicked()
        {
            SceneManager.LoadScene("Game");
            DataStoreMovement.Instance.Health = 1.0f;
            DataFunctions.Instance.OxygenAmount = 0;
            DataStoreMovement.Instance.MoveSpeed = 2f;
        }

        void ExitButtonClicked()
        {
            Application.Quit();
        }
    }
}