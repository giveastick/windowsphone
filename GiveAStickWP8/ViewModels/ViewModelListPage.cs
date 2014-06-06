using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
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

        private string _GroupTag = (string)IsolatedStorageSettings.ApplicationSettings["GroupTag"];
        private string _Nickname = (string)IsolatedStorageSettings.ApplicationSettings["Nickname"];

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

        public void loadSticklist()
        {
            var restClient = new RestClient(Parameters.API_URL);

            var getSticklistRequest = new RestRequest(Parameters.API_GETSTICKLIST_RESOURCE, Method.GET);
            getSticklistRequest.AddUrlSegment("nickname", this.Nickname);
            getSticklistRequest.AddUrlSegment("grouptag", this.GroupTag);

            restClient.ExecuteAsync(getSticklistRequest, getSticklistCallback);
        }


        private void getSticklistCallback(IRestResponse response, RestRequestAsyncHandle handle)
        {
            Stick[] sticks = JsonConvert.DeserializeObject<Stick[]>(response.Content);

            if (sticks != null)
            {
                Sticklist = new ObservableCollection<Stick>();
                int i = 0;
                foreach (Stick item in sticks)
                {
                    item.Order = i;
                    item.Brush = item.getRectangleFillBrush(i);
                    Sticklist.Add(item);
                    i++;
                }
            }
        }

        public void postStickRequest(String receiver)
        {
            var restClient = new RestClient(Parameters.API_URL);

            var postStickRequest = new RestRequest(Parameters.API_POSTSTICK_RESOURCE, Method.POST);
            postStickRequest.AddParameter("giver", this._Nickname);
            postStickRequest.AddParameter("receiver", receiver);
            postStickRequest.AddUrlSegment("grouptag", this._GroupTag);

            restClient.ExecuteAsync(postStickRequest, postStickCallback);
        }

        private void postStickCallback(IRestResponse response, RestRequestAsyncHandle handle)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                loadSticklist();
            }
            else
            {
                MessageBox.Show("Une erreur est survenue lors du batonnage de cet individu. Try again later.");
            }
        }

        #endregion
    }
}
