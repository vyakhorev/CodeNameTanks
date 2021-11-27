
using UnityEngine;

namespace TanksCodeBase
{
  public class LevelManager : MonoBehaviour
  {
    /* Responsible for level transitions - like from a lobby into a battle */
    [SerializeField] GameObject lobbyLevelTree;
    [SerializeField] GameObject trainLevelTree;

    public void fromLobbyToTrain()
    {
      lobbyLevelTree.SetActive(false);
      trainLevelTree.SetActive(true);
    }
    
  }
}