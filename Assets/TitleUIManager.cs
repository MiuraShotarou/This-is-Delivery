using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _fadePanel;
    [SerializeField] private TextMeshProUGUI _pressToStart;
    [SerializeField] private GameObject _menuButtons;
    [SerializeField] private GameObject _stageButtons;
    public void OnActiveMenuButtons() //
    {
        _menuButtons.SetActive(true);
    }
    public void OnInactiveMenuButtons()
    {
        _menuButtons.SetActive(false);
    }
    public void OnActivePressToStart()
    {
        _pressToStart.enabled = true;
    }
    public void OnInactivePressToStart()
    {
        _pressToStart.enabled = false;
    }
    public void OnActiveFadePanel()
    {
        _fadePanel.SetActive(true);
    }
    public void OnInactiveFadePanel()
    {
        _fadePanel.SetActive(false);
    }
    public void OnActiveStageButtons()
    {
        _stageButtons.SetActive(true);
    }
    public void OnInactiveStageButtons()
    {
        _stageButtons.SetActive(false);
    }
    public void OnLoadStageButton(int index)
    {
        SceneManager.LoadScene($"Stage{index}");
    }
    public void OnQuitGameButton()
    {
        Application.Quit();
    }
}
