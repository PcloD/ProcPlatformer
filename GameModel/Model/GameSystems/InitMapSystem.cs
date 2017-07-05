using System;
using System.Collections.Generic;
using Entitas;
using GamePlatformer.Model.GameComponents;
using GamePlatformer.Model.Tiles;
using GamePlatformer.Model.Utils;

namespace GamePlatformer.Model.GameSystems
{
    public class InitMapSystem : IInitializeSystem
    {
        public int sizeX = 128;
        public int sizeY = 32;
        private Dictionary<string, TileDefinition> tileDefinitions;

        public InitMapSystem(Dictionary<string, TileDefinition> tileDefinitions)
        {
            this.tileDefinitions = tileDefinitions;
        }

        public void Initialize()
        {
            Contexts.sharedInstance.map.SetMap(new IntVector2(sizeX, sizeY), new TilePosition(10, 5), new TilePosition(sizeX - 10, 5));

            var game = Contexts.sharedInstance.game;

            var map = Contexts.sharedInstance.map.map;

            for (int x = map.startTilePosition.x; x < map.endTilePosition.x; x++)
            {
                var tileEntity = game.CreateEntity();
                tileEntity.AddTilePosition(new TilePosition(x, map.startTilePosition.y));
                tileEntity.AddTile(tileDefinitions["grass"]);
            }
        }
    }
}
