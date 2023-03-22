using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private UIDocument doc;

    VisualElement root;

    private ProgressBar healthBar;

    void Start()
    {
        root = doc.rootVisualElement;
        healthBar = root.Q<ProgressBar>("HealthBar");

        healthBar.lowValue = 0.0f;
        healthBar.highValue = 1.0f;
    }

    private void Update()
    {
        if (DataStoreMovement.Instance.HitOxygen == true)
        {
            DataStoreMovement.Instance.Health += 0.7f;
            DataStoreMovement.Instance.HitOxygen = false;
        }
        else
        {
            DataStoreMovement.Instance.Health -= 0.08f * Time.deltaTime;
        }
        DataStoreMovement.Instance.Health = Math.Clamp(DataStoreMovement.Instance.Health, 0, 1);
        healthBar.value = DataStoreMovement.Instance.Health;

        if (DataStoreMovement.Instance.Health == 0.0f)
        {
            SceneManager.LoadScene("Death");
        }
    }
}