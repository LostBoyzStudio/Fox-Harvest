using UnityEngine;
using TMPro;

public class PointsUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    PlayerWalletSystem wallet;

    // Start is called before the first frame update
    void Start()
    {
        wallet = FindObjectOfType<PlayerWalletSystem>();
        wallet.onBalanceChange += OnBalanceChange;
        OnBalanceChange(wallet.Balance);
    }
    
    void OnBalanceChange(int current) {
        text.text = "$"+current.ToString()+",00";
    }

    private void OnDestroy() {
        wallet.onBalanceChange -= OnBalanceChange;
    }
}
