using Photon.Pun;

namespace CodeBase._Photon
{
  public class Join : MonoBehaviourPunCallbacks
  {
    public void JoinRoom()
    {
      PhotonNetwork.JoinRandomRoom();
    }
  }
}