using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.Utils.Exceptions;
using Kozyrev_Hriha_SP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kozyrev_Hriha_SP.ViewModels.RegistrationViewModel
{
    public class RegistrationControlVM : INotifyPropertyChanged
    {
        private object currentView;
        private  RegistrationVM registration;
        private  RegistrationSecondVM registration2;
        private  RegistrationThirdVM registration3;
        private  LoginViewModel login;
        private bool isRegistered;
        private readonly IZakaznikRepository zakaznikRepository;
        public event Action<bool> AuthorizationChanged;
        private readonly NavigationVM navigation;


        public RegistrationControlVM(IZakaznikRepository zakaznikRepository,NavigationVM navigation)
        {
            this.zakaznikRepository = zakaznikRepository;
            this.navigation = navigation;
            this.registration = new RegistrationVM(_ => GoToStep2(), _ => Cancel());
            this.registration2 = new RegistrationSecondVM(_ => GoToStep3(), _ => GoToStep1());
            this.registration3 = new RegistrationThirdVM(_ => Registering(), _ => GoToStep2());
            currentView = registration;
        }
        public bool IsRegistered
        {
            get { return isRegistered; }
            set
            {
                if (isRegistered != value)
                {
                    isRegistered = value;
                    OnPropertyChanged(nameof(IsRegistered));
                    AuthorizationChanged?.Invoke(value);
                }
            }
        }
        private void GoToStep1()
        {
            
            CurrentView = registration;
        }

        private void GoToStep2()
        {
            CurrentView = registration2;
        }

        private void GoToStep3()
        {
            CurrentView = registration3;
        }
        private void Cancel()
        {
            CurrentView = navigation.HomePage;
        }
        
        private async void Registering()
        {
            try
            {
                Zakaznik zakaznik = new Zakaznik();
                zakaznik.Jmeno = registration.Name;
                zakaznik.Prijmeni = registration.Surname;
                zakaznik.TelCislo = registration.TelNumber;

                Adresa adresa = new Adresa();
                adresa.Mesto = registration2.City;
                adresa.Ulice = registration2.Street;
                adresa.Psc = registration2.PostCode;
                adresa.CisloPopisne = registration2.House;
                adresa.CisloBytu = registration2.Apart;
                registration3.IsLoggingIn = true;
                NetworkCredential cred = new NetworkCredential(registration3.Email, registration3.Password);
                await Task.Run(()=> zakaznikRepository.AddNewZakaznik(zakaznik, adresa, cred));
                registration3.IsLoggingIn = false;
                navigation.GoToLoginPage();
                
            }catch(Exception ex)
            {
                registration3.ErrorMessage = ex.Message;
                registration3.IsLoggingIn = false;
            }

        }
        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
