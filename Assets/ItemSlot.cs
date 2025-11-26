using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image _itemImage;
    [SerializeField] Sprite[] _itemImageArray;
    private readonly Vector2 _itemImageStartPos = new(0, 150);
    private readonly int _slotLoopCount = 15;
    void Start()
    {
        DOMoveItemSlot();
    }

    void DOMoveItemSlot()
    {
        Sequence sequence = DOTween.Sequence();
        float itemImagePosOrigin = 0;
        float itemImageEndPos = -175;
        float duration = 0.2f;
        for (int i = 0; i < _slotLoopCount; i++)
        {
            sequence.Append(_itemImage.transform.DOLocalMoveY(itemImageEndPos, duration).SetEase(Ease.Linear));
            sequence.AppendCallback(() => _itemImage.transform.localPosition = _itemImageStartPos);
            sequence.AppendCallback(() => _itemImage.sprite = _itemImageArray[Random.Range(0, _itemImageArray.Length)]);
            if (i == 10)
            {
                duration = 0.5f;
            }
            else if (i == _slotLoopCount - 1) //最後のループ
            {
                duration = 1.5f;
                sequence.Append(_itemImage.transform.DOLocalMoveY(itemImagePosOrigin, duration).SetEase(Ease.Linear));
                sequence.AppendCallback(() => _itemImage.transform.localPosition = new(0, itemImagePosOrigin));
            }
        }
        sequence.Play();
    }
}
