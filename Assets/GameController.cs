using UnityEngine;
using UnityEngine.UI;
using Player;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerStatus _playerStatus;
    [SerializeField] private Button _randomColorButton;
    [SerializeField] private Button _upgradeCarryLimitButton;
    [SerializeField] private Button _upgradeSpeedButton;
    [SerializeField] private Renderer objRenderer;
    private int _colorValue = 100;
    private int _carryLimitValue = 300;
    private int _speedValue = 500;

    public void CloseButtonStore ()
    {
        Time.timeScale = 1f;
    }

    public void OpenButtonStore ()
    {
        Time.timeScale = 0f;
    }

    public void RandomColor ()
    {
        if( VerifyMoney(_colorValue) )
        {
            Material newMat = new Material(objRenderer.material);
            newMat.color = new Color(Random.value, Random.value, Random.value);
            objRenderer.material = newMat;
            _playerStatus.CurrentMoney = _playerStatus.CurrentMoney - _colorValue;
            EventBus.RaiseOnUpdateUI();

            Debug.Log(_playerStatus.CurrentMoney);
        }
    }

    public void UpgradeCarryLimit ()
    {
        if ( VerifyMoney(_carryLimitValue) && _playerStatus.MaxStack < 10 )
        {
            _playerStatus.MaxStack++;
            _playerStatus.CurrentMoney = _playerStatus.CurrentMoney - _carryLimitValue;
            EventBus.RaiseOnUpdateUI();

            if ( _playerStatus.PlayerData.moveSpeed == 10 )
            {
                _upgradeCarryLimitButton.GetComponent<Button>().GetComponentInChildren<TMP_Text>().text = "MAX";
                _upgradeCarryLimitButton.GetComponent<Button>().enabled = false;
            }
        }
    }

    public void UpgradeSpeed ()
    {
        if ( VerifyMoney(_speedValue) && _playerStatus.PlayerData.moveSpeed < 5 )
        {
            _playerStatus.PlayerData.moveSpeed++;
            _playerStatus.CurrentMoney = _playerStatus.CurrentMoney - _speedValue;
            EventBus.RaiseOnUpdateUI();

            if ( _playerStatus.PlayerData.moveSpeed == 5 )
            {
                _upgradeSpeedButton.GetComponent<Button>().GetComponentInChildren<TMP_Text>().text = "MAX";
                _upgradeSpeedButton.GetComponent<Button>().enabled = false;
            }
        }
    }

    public bool VerifyMoney (int value)
    {
        return _playerStatus.CurrentMoney >= value;
    }
}
