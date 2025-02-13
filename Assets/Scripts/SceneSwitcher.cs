using UnityEngine;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string _scene;
    [SerializeField] private Text _text;
    [SerializeField] private float _speed = 1f;

    private SceneController sceneController;
    private void Start()
    {
        sceneController = GetComponent<SceneController>();
    }

    private void Update()
    {
        Skip();
        BlinkingText();
    }

    private void BlinkingText()
    {
        if (_text != null)
        {
            Color color = _text.color;
            color.a = Mathf.PingPong(Time.time * _speed, 1f);
            _text.color = color;
        }
    }

    private void Skip()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sceneController.OpenScene(_scene);
        }
    }
}