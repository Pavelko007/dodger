using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public Spawner.Setttings spawnerSetttings;

    public override void InstallBindings()
    {
        Container.BindInstance(spawnerSetttings);
    }
}