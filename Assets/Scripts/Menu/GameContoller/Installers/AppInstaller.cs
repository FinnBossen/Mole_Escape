using Zenject;

public class AppInstaller : MonoInstaller
{


    public override void InstallBindings()
    {

        Container.Bind<UnityInput>().AsSingle();
        Container.Bind<InputRecognizer>().AsTransient();

    }

}