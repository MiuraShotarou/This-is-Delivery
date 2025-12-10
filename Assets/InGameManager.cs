using System;
using UnityEditor.XR;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [SerializeField] GameObject[] _carObjArray;
    void Start()
    {
        ActiveCart();
        Boot();
    }
    void ActiveCart()
    {
        for (int i = 0; i < _carObjArray.Length; i++)
        {
            if (i == GameDataManager.Instance.CarIndex)
            {
                _carObjArray[i].SetActive(true);
            }
            else
            {
                _carObjArray[i].SetActive(false);
            }
        }
    }
    void Boot()
    {
        GameObject player = GameDataManager.Instance.Player;
        Car currentCar = GameDataManager.Instance.CarArray[GameDataManager.Instance.CarIndex];
        player.GetComponent<Engine>().MoveSpeed = currentCar._speed;
        player.GetComponent<Handle>().TurnSpeed = currentCar._curve;
        player.GetComponent<Body>().Weight = currentCar._weight;
        player.GetComponent<Trunk>().MaxPizzaCount = currentCar._maxPizzaCount;
    }
}
