using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Designer_Chat.Core;
using WPF_Designer_Chat.MVVM.Model;

namespace WPF_Designer_Chat.MVVM.ViewModel
{
    class MainViewModel: ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts{ get; set; }

        /* Commands*/
        public RelayCommand SendCommand { get; set; }
        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });
                Message = "";
            });

            Messages.Add(new MessageModel
            {
                Username = "Allisone",
                UsernameColor = "#409aff",
                ImageSource = "https://www.flaticon.com/fr/icone-premium/les-personnes-agees_4310082?term=person&page=1&position=3&page=1&position=3&related_id=4310082&origin=search",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Allisone",
                    UsernameColor = "#409aff",
                    ImageSource = "https://cdn-icons-png.flaticon.com/512/2536/2536748.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }
            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Bunny",
                    UsernameColor = "#409aff",
                    ImageSource = "https://cdn-icons-png.flaticon.com/512/2536/2536748.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                    
                });
            }
            Messages.Add(new MessageModel
            {
                Username = "Bunny",
                UsernameColor = "#409aff",
                ImageSource = "https://cdn-icons-png.flaticon.com/512/2536/2536748.png",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true,

            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username =$"Allison {i}",
                    ImageSource = "https://cdn-icons-png.flaticon.com/512/57/57117.png",
                    Messages = Messages
                });
            }
        }

    }
}
