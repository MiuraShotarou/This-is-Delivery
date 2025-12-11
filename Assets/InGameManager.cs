using UnityEngine;
public class InGameManager : MonoBehaviour
{
    [SerializeField] GameObject[] _carObjArray;
    void Start()
    {
        for (int i = 0; i < GameDataManager.Instance.RacerArray.Length; i++) //レーサーの数が２や４に増減される可能性あり
        {
            ActiveCart(i);
            Boot(i);
        }
    }
    void ActiveCart(int racerIndex)
    {
        for (int i = 0; i < _carObjArray.Length; i++)
        {
            if (i == GameDataManager.Instance.CarIndexArray[racerIndex])
            {
                _carObjArray[i].SetActive(true);
            }
            else
            {
                _carObjArray[i].SetActive(false);
            }
        }
    }
    void Boot(int racerIndex)
    {
        GameObject player = GameDataManager.Instance.Player;
        Car currentCar = GameDataManager.Instance.CarArray[GameDataManager.Instance.CarIndexArray[racerIndex]];
        player.GetComponent<Engine>().MoveSpeed = currentCar._speed;
        player.GetComponent<Handle>().TurnSpeed = currentCar._curve;
        player.GetComponent<Body>().Weight = currentCar._weight;
        player.GetComponent<Trunk>().MaxPizzaCount = currentCar._maxPizzaCount;
    }
}