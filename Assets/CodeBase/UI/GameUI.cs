using CodeBase.Tool_s;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
  public class GameUI : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI coinAmount;

    private void Start()
    {
      Init();
    }

    private void Init()
    {
      coinAmount.text = Constants.GameDefaultCoinValue.ToString();
    }

    public void UpdateCoins(int amount)
    {
      coinAmount.text = amount.ToString();
    }
  }
}