using _Code.Tools.SmartDebug;
using CodeBase.Tool_s;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace CodeBase._Photon
{
  public class Connection : MonoBehaviourPunCallbacks
  {
    [SerializeField] private Auth auth;
    [SerializeField] private GameLoop gameLoop;
    [SerializeField] private bool isDebug;

    public bool test;

    private void Awake()
    {
      #region Debug

      if (isDebug)
        DLogger.Message(DSenders.Multiplayer)
          .WithText($"{Constants.CLASS_Connection} Try to start server...".Bold())
          .WithFormat(DebugFormat.Normal)
          .Log();
      
      #endregion

      PhotonNetwork.AutomaticallySyncScene = true;
      if(PhotonNetwork.IsMasterClient)
        gameLoop.PreparePlayerPrefab();

    }

    private void Start()
    {
      PhotonNetwork.ConnectUsingSettings();
      PhotonNetwork.GameVersion = "1";
    }

    public override void OnConnectedToMaster()
    {
      base.OnConnectedToMaster();
      auth.AuthPlayerNickName();
      
      #region Debug

      if (isDebug)
        DLogger.Message(DSenders.Multiplayer)
          .WithText($"{Constants.CLASS_Connection} Server was started".Bold())
          .WithFormat(DebugFormat.Normal)
          .Log();
      
      #endregion
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
      DLogger.Message(DSenders.Multiplayer)
        .WithText($"Player: [{PhotonNetwork.NickName}] was disconnected by reason: {cause}".Bold().Red())
        .WithFormat(DebugFormat.Normal)
        .Log();
    }

    public override void OnJoinedRoom()
    {
      #region Debug

      if (isDebug)
        DLogger.Message(DSenders.GameState)
          .WithText($"{Constants.CLASS_Connection} Joined the room")
          .WithFormat(DebugFormat.Normal)
          .Log();
          
      #endregion

      if (!test)
      {
        PhotonNetwork.LoadLevel(Constants.SCENE_Menu);
        test = true;
      }
    }

    public override void OnCreatedRoom()
    {
      base.OnCreatedRoom();
      DLogger.Message(DSenders.Multiplayer)
        .WithText($"Room was successfully created".Bold())
        .WithFormat(DebugFormat.Normal)
        .Log();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
      base.OnCreateRoomFailed(returnCode, message);
      
      DLogger.Message(DSenders.Multiplayer)
        .WithText($"Failed to create a room by reason: {message}\n {returnCode}".Bold())
        .WithFormat(DebugFormat.Exception)
        .Log();
    }
  }
}