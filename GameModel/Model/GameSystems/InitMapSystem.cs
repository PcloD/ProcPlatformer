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
        private GameContext gameContext;
        private MapContext mapContext;

        public InitMapSystem(Dictionary<string, TileDefinition> tileDefinitions, GameContext gameContext, MapContext mapContext)
        {
            this.tileDefinitions = tileDefinitions;
            this.gameContext = gameContext;
            this.mapContext = mapContext;
        }

        public void Initialize()
        {
            BuildMap();

            BuildPlayerAvatar();
        }

        private void BuildPlayerAvatar()
        {
            var startingPosition = mapContext.map.startTilePosition.AboveTilePosition().ToBottomMiddleWorldPosition();

            gameContext.isPlayerAvatar = true; //This forces playerAvatarEntity creation
            gameContext.playerAvatarEntity.AddAvatar("alienGreen");
            gameContext.playerAvatarEntity.AddPosition(startingPosition.x, startingPosition.y);
            gameContext.playerAvatarEntity.AddRigidbody(0, 0, true);
            gameContext.playerAvatarEntity.AddSize(TilePositionComponent.TileSize, TilePositionComponent.TileSize * 3 / 2);
        }

        private void BuildMap()
        {
            mapContext.SetMap(new IntVector2(sizeX, sizeY), new TilePosition(0, 1), new TilePosition(sizeX - 10, 1));

            var map = mapContext.map;

            for (int x = map.startTilePosition.x; x < map.endTilePosition.x; x++)
            {
                var tileEntity = gameContext.CreateEntity();
                tileEntity.AddTilePosition(new TilePosition(x, map.startTilePosition.y));
                tileEntity.AddTile(tileDefinitions["grass"]);
            }
        }
    }
}
