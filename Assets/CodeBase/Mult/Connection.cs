using System;
using CodeBase.Tool_s;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Mult
{
  public class Connection : MonoBehaviourPunCallbacks
  {
    private void Start()
    {
      PhotonNetwork.ConnectUsingSettings();
      PhotonNetwork.GameVersion = "1";
    }

    #region Connection

    public override void OnConnectedToMaster()
    {
      Debug.Log("Connected to Master");
    }

    #endregion

    #region Join

    public override void OnJoinedRoom()
    {
      Debug.Log("Joined the room");
      
      PhotonNetwork.LoadLevel(Constants.SCENE_Menu);
    }

    #endregion
    
    #region Leave

    public void Leave()
    {
      PhotonNetwork.LeaveRoom();
    }

    #endregion
  }
}