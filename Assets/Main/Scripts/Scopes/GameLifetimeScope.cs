using Main.Scripts;
using Main.Scripts.Environment;
using Main.Scripts.UI;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameManager>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        
        builder.RegisterComponentInHierarchy<PlayerMovement>().AsSelf().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<PlayerUnit>().AsSelf().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<FinishUnit>().AsSelf().AsImplementedInterfaces();
        
        builder.RegisterComponentInHierarchy<EndgameUI>().AsSelf().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<FinishUI>().AsSelf().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<GameUI>().AsSelf().AsImplementedInterfaces();
        
        builder.Register<PlayerInputHandler>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        builder.Register<TestProgActions>(Lifetime.Singleton).AsSelf();
        
       
    }
}
