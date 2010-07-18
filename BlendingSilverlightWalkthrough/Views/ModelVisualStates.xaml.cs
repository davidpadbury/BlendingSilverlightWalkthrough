using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Navigation;
using BlendingSilverlightWalkthrough.ViewModels;

namespace BlendingSilverlightWalkthrough
{
    public partial class ModelVisualStates : Page
    {
        public ModelVisualStates()
        {
            InitializeComponent();

            ViewModel = new ModelVisualStatesViewModel();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public ModelVisualStatesViewModel ViewModel
        {
            get { return (ModelVisualStatesViewModel) DataContext; }
            set { DataContext = value; }
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }
    }
}
