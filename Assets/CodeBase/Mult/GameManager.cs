using System;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Mult
{
  public class GameManager : MonoBehaviourPunCallbacks
  {
    [SerializeField] private Transform playerPrefab;
    private Vector3 _spawnPosition = new Vector3(0, 0, 0);

    private void Awake()
    {
      GeneratePlayerSpawnPosition();
    }

    #region _GAME

    private void GeneratePlayerSpawnPosition()
    {
      float range = Random.Range(-5f, 5f);
      _spawnPosition = new Vector3(range, 1, range);

      if (PhotonNetwork.IsMasterClient)
      {
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
      }
    }

    #endregion
  }
}