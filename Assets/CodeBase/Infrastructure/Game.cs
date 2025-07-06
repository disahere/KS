using System.Collections;
using _Code.Tools.SmartDebug;
using CodeBase._Photon;
using CodeBase.Tool_s;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class Game : MonoBehaviourPunCallbacks
  {
    [Header("Photon Connection")]
    [SerializeField] private Connection connection;

    private void Start()
    {
      StartCoroutine(InitLoadMenu());
    }

    private IEnumerator InitLoadMenu()
    {
      yield return new WaitForSeconds(Constants.GameCheckCooldown);
      
      connection.OnJoinedRoom();
      DLogger.Message(DSenders.GameState)
        .WithText($"{Constants.CLASS_Connection} Init load menu was done".Bold().Green())
        .WithFormat(DebugFormat.Normal)
        .Log();
    }
  }
}