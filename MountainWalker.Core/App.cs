using System.Diagnostics;
using MvvmCross.Platform.IoC;

namespace MountainWalker.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            RegisterNavigationServiceAppStart<ViewModels.StartViewModel>();
        }
    }
}
