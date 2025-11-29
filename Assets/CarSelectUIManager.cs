using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelectUIManager : MonoBehaviour
{
    public void OnLoadStageButton()
    {
        SceneManager.LoadScene($"Stage{GameDataManager.Instance.StageIndex}");
    }
}