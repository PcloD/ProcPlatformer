using Entitas;
using GamePlatformer.Model.GameSystems;
using System.Collections.Generic;
using GamePlatformer.Model.Tiles;

namespace GamePlatformer.Model
{
    public class GameModelSystems
    {
        private Systems systems;
        private readonly Dictionary<string, TileDefinition> tileDefinitions = new Dictionary<string, TileDefinition>();

        public GameModelSystems()
        {
            InitTileDefinitions();

            InitSystems();
        }

        private void InitTileDefinitions()
        {
            AddTileDefinition("grass");
        }

        private void AddTileDefinition(string id)
        {
            tileDefinitions.Add(id, new TileDefinition(id));
        }

        private void InitSystems()
        { 
            systems = new Systems()
                .Add(new InitMapSystem(tileDefinitions, Contexts.sharedInstance.game, Contexts.sharedInstance.map))
                .Add(new HandlePlayerAvatarInputSystem(Contexts.sharedInstance.input, Contexts.sharedInstance.game))
                .Add(new MovementSystem(Contexts.sharedInstance.game))
                .Add(new UpdateSystem());

            systems.Initialize();
        }

        public void ExecuteSystems()
        {
            systems.Execute();
            systems.Cleanup();
        }

        public void TearDownSystems()
        {
            systems.TearDown();
        }
    }
}
