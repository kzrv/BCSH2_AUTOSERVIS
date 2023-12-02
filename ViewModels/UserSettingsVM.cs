using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Kozyrev_Hriha_SP.Service;
using Kozyrev_Hriha_SP.Service.Interfaces;

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
        private string _errorMessage;
        private string _errorMessagePass;

        private readonly IUpdateUserProfileService _profileService;
        private readonly NotificationService _notificationService;

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
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public string ErrorMessagePass
        {
            get { return _errorMessagePass; }
            set
            {
                _errorMessagePass = value;
                OnPropertyChanged(nameof(ErrorMessagePass));
            }
        }


        public ICommand SelectImageCommand { get; }
        public ICommand ChangePasswordCommand { get; }
        public ICommand SavePassCommand { get; }
        public ICommand SaveCommand { get; }
        public UserSettingsVM(IUpdateUserProfileService profileService, NavigationVM navigationVm, NotificationService notificationService)
        {
            _notificationService = notificationService;
            _profileService = profileService;
            _navigationVM = navigationVm;
            CurrUser = _navigationVM.AuthorizedUser;
            UserAvatarImg = _navigationVM.BinaryImageData;
            SelectImageCommand = new ViewModelCommand(SelectImage);
            ChangePasswordCommand = new ViewModelCommand(ChangePassword);
            SaveCommand = new ViewModelCommand(SaveChanges, CanSaveChanges);
            CurrZakaznik = _profileService.GetZakaznikById(CurrUser.UserId);
            Adresa = _profileService.GetUserAdresa(CurrZakaznik.IdAdresa);
            SavePassCommand = new ViewModelCommand(SaveChangesPass, CanSaveChangesPass);

        }

        private bool CanSaveChangesPass(object obj)
        {
            if (!string.IsNullOrEmpty(NewPassword) && NewPassword.Length > 3)
            {
                ErrorMessagePass = "";
                return true;
            }

            ErrorMessagePass = "* The password field must not be empty and must contain more than 3 characters";
            return false;
        }

        private void SaveChangesPass(object obj)
        {
            NetworkCredential n = new NetworkCredential(CurrUser.Email, NewPassword);
            _profileService.UpdateUserPassword(_currUser, n);
            _notificationService.ShowNotification("PASSWORD WAS CHANGED", NotificationType.Success);
            IsPasswordChanging = false;
        }

        private bool CanSaveChanges(object obj)
        {
            if (!string.IsNullOrEmpty(CurrZakaznik.Jmeno) &&
                !string.IsNullOrEmpty(CurrZakaznik.Prijmeni) &&
                !string.IsNullOrEmpty(CurrZakaznik.TelCislo) &&
                !string.IsNullOrEmpty(Adresa.Ulice) &&
                !string.IsNullOrEmpty(Adresa.Mesto) &&
                !string.IsNullOrEmpty(Adresa.CisloPopisne) &&
                !string.IsNullOrEmpty(Adresa.Psc) &&
                !string.IsNullOrEmpty(CurrUser.Email))
            {
                ErrorMessage = "";
                return true;
            }

            ErrorMessage = "* Fill in all the fields";
            return false;

        }

        private void SaveChanges(object obj)
        {
            _profileService.UpdateZakaznikProfile(CurrUser, CurrZakaznik, BinaryContent, Adresa);
            _navigationVM.BinaryImageData = UserAvatarImg;
            _notificationService.ShowNotification("CHANGES WAS SAVED", NotificationType.Success);
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


                UserAvatarImg = File.ReadAllBytes(selectedFilePath);

                BinaryContent = new BinaryContent
                {
                    IdContent = CurrUser.IdContent,
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
