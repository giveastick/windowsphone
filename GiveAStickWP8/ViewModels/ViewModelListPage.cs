using Microsoft.Phone.Shell;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WP.Core;

namespace GiveAStickWP8.ViewModels
{
    public class ViewModelListPage : ObservableObject
    {
        #region Fields

        private string _GroupTag = (string)PhoneApplicationService.Current.State["GroupTag"];
        private string _Nickname = (string)PhoneApplicationService.Current.State["Nickname"];

        private DelegateCommand _AddStickCommand;
        private DelegateCommand _SelectedContact;

        private ObservableCollection<Stick> _Sticklist; 

        public ObservableCollection<Stick> Sticklist
        {
            get { return _Sticklist; }
            set { OnPropertyChanging(); _Sticklist = value; OnPropertyChanged(); }
        }
        

        #endregion

        #region Properties

        public DelegateCommand SelectedContact
        {
            get { return _SelectedContact; }
        }

        public string GroupTag 
        {
            get { return _GroupTag; }
        }
        public string Nickname 
        {
            get { return _Nickname; }
        }

        public DelegateCommand AddStickCommand
        {
            get { return _AddStickCommand; }
            set { _AddStickCommand = value; }
        }

        #endregion

        #region Constructors

        public ViewModelListPage()
        {
            loadSticklist();
            _SelectedContact = new DelegateCommand(ExecuteSelectedContact, CanExecuteSelectContact);
        }

        #endregion

        #region Methods     

        private bool CanExecuteSelectContact(object parameters)
        {
            return true;
        }

        private void ExecuteSelectedContact(object parameters)
        {
            try
            {
                if (MessageBoxResult.OK == MessageBox.Show("Êtes-vous sûr de vouloir donner un batton à " + Nickname + " ?", "Donner", MessageBoxButton.OKCancel))
                {
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur d'ajout du batton.");
            }
        }

        private void loadSticklist()
        {
            var restClient = new RestClient(Parameters.API_URL);

            var getSticklistRequest = new RestRequest(Parameters.API_GETSTICKLIST_RESOURCE, Method.GET);
            getSticklistRequest.AddUrlSegment("nickname", this.Nickname);
            getSticklistRequest.AddUrlSegment("grouptag", this.GroupTag);

            restClient.ExecuteAsync(getSticklistRequest, getSticklistCallback);
        }

        private void getSticklistCallback(IRestResponse response, RestRequestAsyncHandle handle)
        {
            Console.Out.WriteLine(response);
            var sticksJson = SimpleJson.DeserializeObject(response.Content) as Array;

            foreach (dynamic item in sticksJson)
            {
              string nickname =  item.nickname;
              int balance =  item.balance;

              Stick stick = new Stick();
              stick.setNickname(nickname);
              stick.setBalance(balance);
            }
            /*
            Sticklist = new ObservableCollection<Stick>();
            for(int i = 0; i<sticksJson.length(); i++)
            {
                Sticklist.Add(Stick.fromJsonString(sticksJson.GetHashCo);
            }
            */
            // Transformer var toto en stick
            // Ajouter toto à observable collection


            


            

            //throw new NotImplementedException();
        }

        // Cette méthode ne fonctionne pas
        private void ExecuteAddStick(object parameters)
        {
            try
            {
                if (MessageBoxResult.OK == MessageBox.Show("Êtes-vous sûr de vouloir donner un batton à " + Nickname + " ?", "Donner", MessageBoxButton.OKCancel))
                {
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur d'ajout du batton.");
            }
        }

        // Cette méthode ne fonctionne pas
        private bool CanExecuteAddStick(object parameters)
        {
            return true;
        }

        #endregion
    }
}
