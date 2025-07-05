using Photon.Pun;
using Photon.Realtime;

namespace CodeBase._Photon
{
  public class Create : MonoBehaviourPunCallbacks
  {
    public void CreateRoom()
    {
      RoomOptions roomOptions = new RoomOptions
      {
        MaxPlayers = 20,
        IsOpen = true,
        IsVisible = true
      };

      PhotonNetwork.CreateRoom("Main", roomOptions);
    }
  }
}