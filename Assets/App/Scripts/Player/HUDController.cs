using UnityEngine;
using Player;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtMoney;
    [SerializeField] private TMP_Text _txtStack;

    [SerializeField] private PlayerStatus _playerStatus;

    private void OnEnable ()
    {
        EventBus.OnTradeEnemy += UpdateMoney;
        EventBus.OnStackEnemy += UpdateStack;
        EventBus.OnUpdateUI += UpdateUI;
    }

    private void OnDisable ()
    {
        EventBus.OnTradeEnemy -= UpdateMoney;
        EventBus.OnStackEnemy -= UpdateStack;
        EventBus.OnUpdateUI += UpdateUI;
    }

    public void UpdateMoney ()
    {
        _playerStatus.CurrentMoney += 100;

        _txtMoney.text = _playerStatus.CurrentMoney.ToString();
    }

    public void UpdateStack ()
    {
        _txtStack.text = _playerStatus.CurrentStack + "/" + _playerStatus.MaxStack;
    }

    public void UpdateUI ()
    {
        _txtMoney.text = _playerStatus.CurrentMoney.ToString();
        _txtStack.text = _playerStatus.CurrentStack + "/" + _playerStatus.MaxStack;
    }
}
