using System.Windows.Controls;

namespace Sdk.Plugin
{
    /// <summary>
    /// Control.xaml interaction logic
    /// </summary>
    public partial class Control : UserControl
    {
        public Plugin Plugin { get; }

        public Control()
        {
            InitializeComponent();
        }

        public Control(Plugin plugin) : this()
        {
            this.Plugin = plugin;
        }


    }
}
