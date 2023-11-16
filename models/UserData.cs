﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Kozyrev_Hriha_SP.Models
{
    [Table("USER_DATA")]
    public class UserData : INotifyPropertyChanged
    {
        private int userId;
        private string email;
        private string password;
        private int binaryContentIdContent;

        [Column("ID_USER"), Key]

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

        [Required]
        [StringLength(50)]
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

        [Required]
        [StringLength(50)]
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        [Column("BINARY_CONTENT_ID_CONTENT")]
        public int BinaryContentIdContent
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
 

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}