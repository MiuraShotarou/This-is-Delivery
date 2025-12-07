using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CarSelectUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _carNameText;
    [SerializeField] GameObject[] _carObjArray;
    int _CarIndex
    {
        get => _carIndex;
        set
        {
            _carIndex = value;
            if (_carIndex > _maxCarIndex)
            {
                _carIndex = 0;
            }
            else if (_carIndex < 0)
            {
                _carIndex = _maxCarIndex;
            }
        }
    }
    void Awake()
    {
        _maxCarIndex = _carObjArray.Length - 1;
        _carNameText.text = _carObjArray[_CarIndex].name;
    }
    public void OnCarChangeButton([System.ComponentModel.Description("左向きの矢印を表示")] bool isLeftArrow)
    {
        _carObjArray[_CarIndex].SetActive(false);
        _CarIndex += isLeftArrow? -1 : 1;
        _carObjArray[_CarIndex].SetActive(true);
        _carNameText.text = _carObjArray[_CarIndex].name;
    }
    public void OnRaceStartButton()
    {
        SceneManager.LoadScene($"Stage{GameDataManager.Instance.StageIndex}");
    }
    int _carIndex;
    private int _maxCarIndex;
}