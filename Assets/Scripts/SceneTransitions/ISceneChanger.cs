using Game.Data;

namespace Game.SceneTransitions
{
    public interface ISceneChanger
    {
        public void ChangeScene(SceneToLoadSo sceneToLoad);
    }

}
