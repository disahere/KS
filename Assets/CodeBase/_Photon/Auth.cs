using _Code.Tools.SmartDebug;
using CodeBase.Tool_s;
using Photon.Pun;
using UnityEngine;

namespace CodeBase._Photon
{
  public class Auth : MonoBehaviourPunCallbacks
  {
    [SerializeField] private bool isDebug;

    public void AuthPlayerNickName()
    {
      int num = Random.Range(0, 1000);
      PhotonNetwork.NickName = $"Player {num}";
      
      #region Debug

      DLogger.Message(DSenders.SceneData)
        .WithText($"{Constants.CLASS_Auth} {PhotonNetwork.NickName} was connected to server")
        .WithFormat(DebugFormat.Normal)
        .Log();

      #endregion
    }
  }
}