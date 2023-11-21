
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kozyrev_Hriha_SP.Models.Enum;

namespace Kozyrev_Hriha_SP.Models
{
    public class UserData : INotifyPropertyChanged
    {
        private int userId;
        private string email;
        private int binaryContentIdContent;
        private Role role;

        public int UserId
        {
            get { return userId; }
            set
            {
                if (userId != value)
                {
                    userId = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }
        public int IdContent
        {
            get { return binaryContentIdContent; }
            set
            {
                if (binaryContentIdContent != value)
                {
                    binaryContentIdContent = value;
                    OnPropertyChanged();
                }
            }
        }
        public Role RoleUser
        {
            get { return role; }
            set
            {
                if (role != value)
                {
                    role = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
