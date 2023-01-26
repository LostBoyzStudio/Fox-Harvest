using UnityEngine;

public class PlayerWalletSystem : PlayerSystem
{
    [SerializeField]
    private int _cash = 0;

    public delegate void OnBalanceChange(int current);
    public OnBalanceChange onBalanceChange;

    public int Balance
    {
        get => _cash;
    }

    internal void CashOut(int value)
    {
        _cash = _cash - value;
        onBalanceChange?.Invoke(_cash);
    }

    internal void CashIn(int value)
    {
        _cash = _cash + value;
        onBalanceChange?.Invoke(_cash);
    }
}
