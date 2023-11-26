using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class UserSettingsVM : ViewModelBase
    {
        private UserData _currUser;
        private Zakaznik _currZakaznik;
        private Adresa _adresa;
        private BinaryContent _binaryContent;
        private byte[] _userAvatarImg;
        private NavigationVM _navigationVM;
        private bool _isPasswordChanging;
        private string _newPassword;
        private readonly IServiceProvider ServiceProvider;

        private readonly IZakaznikRepository zakaznikRepository;

        public UserData CurrUser
        {
            get { return _currUser; }
            set
            {
                _currUser = value;
                OnPropertyChanged(nameof(CurrUser));
            }
        }

        public Zakaznik CurrZakaznik
        {
            get { return _currZakaznik; }
            set
            {
                _currZakaznik = value;
                OnPropertyChanged(nameof(CurrZakaznik));
            }
        }

        public Adresa Adresa
        {
            get { return _adresa; }
            set
            {
                _adresa = value;
                OnPropertyChanged(nameof(Adresa));
            }
        }

        public BinaryContent BinaryContent
        {
            get { return _binaryContent; }
            set
            {
                _binaryContent = value;
                OnPropertyChanged(nameof(BinaryContent));
            }
        }
        public byte[] UserAvatarImg
        {
            get { return _userAvatarImg; }
            set
            {
                _userAvatarImg = value;
                OnPropertyChanged(nameof(UserAvatarImg));
            }
        }
        public bool IsPasswordChanging
        {
            get { return _isPasswordChanging; }
            set
            {
                _isPasswordChanging = value;
                OnPropertyChanged(nameof(IsPasswordChanging));
            }
        }

        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }


        public ICommand SelectImageCommand { get; }
        public ICommand ChangePasswordCommand { get; }
        public ICommand SaveCommand { get; }
        public UserSettingsVM(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _navigationVM = serviceProvider.GetService<NavigationVM>();
            CurrUser = _navigationVM.AuthorizedUser;
            UserAvatarImg = _navigationVM.BinaryImageData;
            SelectImageCommand = new ViewModelCommand(SelectImage);
            ChangePasswordCommand = new ViewModelCommand(ChangePassword);
            SaveCommand = new ViewModelCommand(SaveChanges, CanSaveChanges);
            zakaznikRepository = serviceProvider.GetService<IZakaznikRepository>();
            CurrZakaznik = zakaznikRepository.GetZakaznikByUserId(CurrUser.UserId).First();
            Adresa = zakaznikRepository.GetZakaznikAddress(CurrZakaznik.IdAdresa).First();

        }

        private bool CanSaveChanges(object obj)
        {
            return !string.IsNullOrEmpty(CurrZakaznik.Jmeno) &&
                   !string.IsNullOrEmpty(CurrZakaznik.Prijmeni) &&
                   !string.IsNullOrEmpty(CurrZakaznik.TelCislo) &&
                   !string.IsNullOrEmpty(Adresa.Ulice) &&
                   !string.IsNullOrEmpty(Adresa.Mesto) &&
                   !string.IsNullOrEmpty(Adresa.CisloPopisne) &&
                   !string.IsNullOrEmpty(Adresa.Psc) &&
                   !string.IsNullOrEmpty(CurrUser.Email);
            //TODO: Add password

        }

        private void SaveChanges(object obj)
        {
            zakaznikRepository.UpdateUserData(CurrZakaznik, Adresa, CurrUser, BinaryContent, NewPassword);
        }

        private void ChangePassword(object obj)
        {
            IsPasswordChanging = !IsPasswordChanging;
            NewPassword = "";
        }

        private void SelectImage(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;

                byte[] fileBytes = File.ReadAllBytes(selectedFilePath);

                // Set the UserAvatar property to the selected image
                UserAvatarImg = File.ReadAllBytes(selectedFilePath);

                BinaryContent = new BinaryContent
                {
                    BinarniObsah = fileBytes,
                    NazevSouboru = Path.GetFileName(selectedFilePath),
                    TypSouboru = Path.GetExtension(selectedFilePath),
                    Pripona = Path.GetExtension(selectedFilePath).TrimStart('.'),
                    DatumNahrani = DateTime.Now,
                    DatumZmeny = DateTime.Now,
                    Zmenil = CurrUser.UserId.ToString(),
                    Operace = "Update"
                };

            }
        }

    }
}
