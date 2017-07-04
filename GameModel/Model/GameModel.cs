using Entitas;
using GamePlatformer.Model.GameSystems;

namespace GamePlatformer.Model
{
    public class GameModel
    {
        private Systems modelSystems;
        private Systems renderSystems;

        public GameModel()
        {
            modelSystems = new Systems()
                .Add(new UpdateSystem());

            renderSystems = new Systems();

            modelSystems.Initialize();
            renderSystems.Initialize();
        }

        public void ExecuteModelSystems()
        {
            modelSystems.Execute();
        }

        public void ExecuteRenderSystems()
        {
            renderSystems.Execute();
        }
    }
}
