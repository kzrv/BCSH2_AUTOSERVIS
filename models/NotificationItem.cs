using System.Windows.Media;
using System.Windows.Threading;
using Kozyrev_Hriha_SP.ViewModels;

namespace Kozyrev_Hriha_SP.Models
{

    public class NotificationItem : ViewModelBase
    {

        private string _message;
        private SolidColorBrush _backgroundColor;
        private DispatcherTimer _timer;
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged(nameof(Message));

                }
            }
        }
        public SolidColorBrush BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                if (_backgroundColor != value)
                {
                    _backgroundColor = value;
                    OnPropertyChanged(nameof(BackgroundColor));

                }
            }
        }
        public DispatcherTimer Timer
        {
            get { return _timer; }
            set
            {
                if (_timer != value)
                {
                    _timer = value;
                    OnPropertyChanged(nameof(Timer));

                }
            }
        }
    }
}
    