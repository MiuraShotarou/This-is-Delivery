using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CarSelectUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _carNameText;
    [SerializeField] Slider[] _statusSliderArray;
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
    // ただのキャッシュ
    Car _currentCar;
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
        _currentCar = GameDataManager.Instance.CarArray[_CarIndex];
        ShowStatusUI();
    }
    void ShowStatusUI()
    {
        _statusSliderArray[0].value = _currentCar._speed;
        _statusSliderArray[1].value = _currentCar._weight;
        _statusSliderArray[2].value = _currentCar._curve;
        _statusSliderArray[3].value = _currentCar._maxPizzaCount;
    }
    public void OnRaceStartButton()
    {
        SceneManager.LoadScene($"Stage{GameDataManager.Instance.StageIndex}");
    }
    int _carIndex;
    private int _maxCarIndex;
}