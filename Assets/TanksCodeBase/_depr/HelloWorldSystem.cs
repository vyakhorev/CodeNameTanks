using Entitas;

namespace TanksCodeBase
{
  public class HelloWorldSystem : IInitializeSystem
  { 
    // always handy to keep a reference to the context 
    // we're going to be interacting with it
    readonly GameContext gameContext;

    public HelloWorldSystem(Contexts contexts)
    { 
      // get the context from the constructor
      gameContext = contexts.game;
    }

    public void Initialize()
    {
      // create an entity and give it a DebugMessageComponent with
      // the text "Hello World!" as its data
      gameContext.CreateEntity().AddDebugMessage("Hello World!");
    }
  }
}