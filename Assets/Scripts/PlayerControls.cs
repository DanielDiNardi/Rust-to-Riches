using System;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
  public enum Improvements
  {
    Sphere,
    Cube
  }

  public Improvements selectedImprovementType = Improvements.Sphere;
  readonly Dictionary<Improvements, GameObject> improvementGameObjects = new();

  private GameObject GetChildGameObject(GameObject fromGameObject, string withName)
  {
    Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
    foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
    return null;
  }

  private void SetImprovementToActive(GameObject improvementTypeUI)
  {
    Debug.Log("SetImprovementToActive");
    if (improvementTypeUI == null)
    {
      Debug.LogError("ImprovementTypeUI is null");
      return;
    }

    Debug.Log("ImprovementTypeUI: " + improvementTypeUI.name);
    GameObject Background = GetChildGameObject(improvementTypeUI, "Background");
    GameObject Text = GetChildGameObject(improvementTypeUI, "Text");

    if (Background.TryGetComponent(out Image background))
    {
      if (UnityEngine.ColorUtility.TryParseHtmlString("#373737", out Color color))
      {
        background.color = color;
      }
    }

    if (Text.TryGetComponent(out TextMeshProUGUI text))
    {
      text.color = Color.white;
    }
  }

  private void SetImprovementToInactive(GameObject improvementTypeUI)
  {
    Debug.Log("SetImprovementToInactive");
    if (improvementTypeUI == null)
    {
      Debug.LogError("ImprovementTypeUI is null");
      return;
    }

    Debug.Log("ImprovementTypeUI: " + improvementTypeUI.name);
    GameObject Background = GetChildGameObject(improvementTypeUI, "Background");
    GameObject Text = GetChildGameObject(improvementTypeUI, "Text");

    if (Background.TryGetComponent(out Image background))
    {
      background.color = Color.white;
    }

    if (Text.TryGetComponent(out TextMeshProUGUI text))
    {
      text.color = Color.black;
    }
  }

  private void UpdateImprovementUI()
  {
    foreach (var improvementGameObject in improvementGameObjects)
    {
      Debug.Log("ImprovementGameObject: " + improvementGameObject.Key + " " + improvementGameObject.Value.name);
      if (improvementGameObject.Key == selectedImprovementType)
      {
        SetImprovementToActive(improvementGameObject.Value);
        continue;
      }

      SetImprovementToInactive(improvementGameObject.Value);
    }
  }

  private void HandleKeyboardInput()
  {
    if (Input.GetKeyDown(KeyCode.Q))
    {
      Debug.Log("Q key was pressed");
      selectedImprovementType = Improvements.Sphere;
      UpdateImprovementUI();
    }

    if (Input.GetKeyDown(KeyCode.W))
    {
      Debug.Log("W key was pressed");
      selectedImprovementType = Improvements.Cube;
      UpdateImprovementUI();
    }
  }

  public void Start()
  {
    GameObject improvementUI = GameObject.Find("ImprovementSelectorUI");
    Transform improvementUITransform = improvementUI.transform;

    improvementGameObjects.Add(Improvements.Sphere, improvementUITransform.Find("SphereImprovement").GameObject());
    improvementGameObjects.Add(Improvements.Cube, improvementUITransform.Find("CubeImprovement").GameObject());
  }

  public void Update()
  {
    HandleKeyboardInput();
  }
}