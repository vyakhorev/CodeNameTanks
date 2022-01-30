using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  public class AuthInteractiveBuildingsSystem : IInitializeSystem
  {
    readonly GameContext _game;
    
    public AuthInteractiveBuildingsSystem(Contexts contexts)
    {
      _game = contexts.game;
    }
    
    public void Initialize()
    {
      InteractiveBuildingAthoring[] listToAuthor = MonoBehaviour.FindObjectsOfType<InteractiveBuildingAthoring>();
      foreach (InteractiveBuildingAthoring comp_i in listToAuthor)
      {
        GameEntity interactiveBuilding = GameController.instance.gameContext.CreateEntity();
        interactiveBuilding.AddViewPrefab(comp_i.interactiveBuildingPrefab);
        interactiveBuilding.AddPosition(comp_i.transform.position);
        interactiveBuilding.AddRotation(comp_i.transform.rotation);
        interactiveBuilding.AddInteractiveZone(newWaitedTime: 0f,
                                               newTimeToTrigger: comp_i.timeToTrigger,
                                               newIsTriggered: false,
                                               newRadius: comp_i.radius);
        switch (comp_i.buildingType)
        {
          case EnumBuildingTypes.LevelTeleporter:
          {
            interactiveBuilding.AddLobbyTeleport(EnumLevelTypes.Cooperative); 
            break;
          }
          case EnumBuildingTypes.UpgradeFactory:
          {

            break;
          }
        }

        comp_i.gameObject.Link(interactiveBuilding);

      }
    }
    
  }
}