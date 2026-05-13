
using cmasacoS5B.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace cmasacoS5B
{
    public partial class App : Application
    {
        public static PersonRepository PersonRepo { get; private set; }

        public App(PersonRepository repo)
        {
            InitializeComponent();
            PersonRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}