using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Deaths : MonoBehaviour
{

    [SerializeField]
    private UIDocument doc;

    VisualElement root;

    private Label deaths;
    void Start()
    {
        root = doc.rootVisualElement;
        deaths = root.Q<Label>("Deaths");

        deaths.text = DataStoreMovement.Instance.Death.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
