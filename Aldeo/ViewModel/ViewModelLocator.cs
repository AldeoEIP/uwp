using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Aldeo.ViewModel {
    public class ViewModelLocator {/// <summary>
                                   /// Initializes a new instance of the ViewModelLocator class.
                                   /// </summary>
        public ViewModelLocator() {
            ServiceLocator.SetLocatorProvider (() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel> ();
            SimpleIoc.Default.Register<PencilCaseViewModel> ();
            SimpleIoc.Default.Register<CompanionViewModel> ();
            SimpleIoc.Default.Register<CalendarViewModel> ();
            SimpleIoc.Default.Register<DictionaryViewModel> ();
            SimpleIoc.Default.Register<EncyclopediaViewModel> ();
            SimpleIoc.Default.Register<CalculatorViewModel> ();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel> ();
        public PencilCaseViewModel PencilCase => ServiceLocator.Current.GetInstance<PencilCaseViewModel> ();
        public CompanionViewModel Companion => ServiceLocator.Current.GetInstance<CompanionViewModel> ();
        public CalendarViewModel Calendar => ServiceLocator.Current.GetInstance<CalendarViewModel> ();
        public DictionaryViewModel Dictionary => ServiceLocator.Current.GetInstance<DictionaryViewModel> ();
        public EncyclopediaViewModel Encyclopedia => ServiceLocator.Current.GetInstance<EncyclopediaViewModel> ();
        public CalculatorViewModel Calculator => ServiceLocator.Current.GetInstance<CalculatorViewModel> ();

        public static void Cleanup() {
            // TODO Clear the ViewModels
        }
    }
}