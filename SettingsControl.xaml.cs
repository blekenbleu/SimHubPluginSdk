using System.Windows.Controls;

namespace User.PluginSdk
{
    /// <summary>
    /// Logique d'interaction pour SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public DataPlugin Plugin { get; }

        public SettingsControl()
        {
            InitializeComponent();
        }

        public SettingsControl(DataPlugin plugin) : this()
        {
            this.Plugin = plugin;
        }


    }
}
