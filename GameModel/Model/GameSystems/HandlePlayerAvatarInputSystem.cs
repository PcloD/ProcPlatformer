using System;
using System.Collections.Generic;
using Entitas;
using GamePlatformer.Model.GameComponents;
using GamePlatformer.Model.Utils;

namespace GamePlatformer.Model.GameSystems
{
    public class HandlePlayerAvatarInputSystem : ReactiveSystem<InputEntity>
    {
        private GameContext gameContext;

        public HandlePlayerAvatarInputSystem(InputContext inputContext, GameContext gameContext) : base(inputContext)
        {
            this.gameContext = gameContext;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.PlayerAvatarInput);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasPlayerAvatarInput;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach(var entity in entities)
            {
                var horizontalDirection = entity.playerAvatarInput.horizontalDirection;
                var jump = entity.playerAvatarInput.jump;

                var playerEntity = gameContext.playerAvatarEntity;

                playerEntity.rigidbody.speedX = horizontalDirection * 5;

                if (jump && AvatarUtils.IsOnFloor(playerEntity, gameContext))
                    playerEntity.rigidbody.speedY = -15;

                entity.Destroy();
            }
        }

    }
}
