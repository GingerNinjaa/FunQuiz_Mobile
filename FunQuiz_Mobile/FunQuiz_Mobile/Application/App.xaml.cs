using Autofac;
using System.Reflection;
using Xamarin.Forms;

namespace FunQuiz_Mobile
{
    public partial class App : Application
    {
        public static IContainer Container;

        public App()
        {
            InitializeComponent();

            //AUTOFAC
            //class used for registration
            var builder = new ContainerBuilder();
            //scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .AsImplementedInterfaces()
                .AsSelf();
            Container = builder.Build();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
