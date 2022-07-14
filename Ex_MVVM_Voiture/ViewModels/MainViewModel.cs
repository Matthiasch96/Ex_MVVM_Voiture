using Ex_MVVM_Voiture.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex_MVVM_Voiture.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        // Event
        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // Fields 

        private int _counter;
        private string _Info;
        private string _StartStop = "Démarrer";
        // Props 

        public string StartStop
        {
            get { return _StartStop; }
            set
            {
                _StartStop = value;

                RaisePropertyChanged();
            }
        }
        public int Counter
        {
            get { return _counter; }
            set
            {
                _counter = value;

                RaisePropertyChanged();

                CommandAcc?.RaiseCanExecuteChanged();
                CommandFreiner?.RaiseCanExecuteChanged();
            }
        }
        public string Info
        {
            get { return _Info; }
            set
            {
                _Info = _Info + value + "\n";

                RaisePropertyChanged();


                CommandStartStop?.RaiseCanExecuteChanged();
                CommandAcc?.RaiseCanExecuteChanged();
                CommandFreiner?.RaiseCanExecuteChanged();
                CommandTurnLeft?.RaiseCanExecuteChanged();
                CommandTurnRight?.RaiseCanExecuteChanged();

            }

        }


        public IRelayCommand CommandStartStop { get; set; }
        public IRelayCommand CommandAcc { get; set; }
        public IRelayCommand CommandFreiner { get; set; }
        public IRelayCommand CommandTurnLeft { get; set; }
        public IRelayCommand CommandTurnRight { get; set; }




        public MainViewModel()
        {
            Counter = 0;


            CommandAcc = new RelayCommand(IncrCounter, IncrCheck);
            CommandFreiner = new RelayCommand(DecrCounter, DecrCheck);
            CommandTurnLeft = new RelayCommand(TurnLeft);
            CommandTurnRight = new RelayCommand(TurnRight);
            CommandStartStop = new RelayCommand(StartToStop);
        }


        private void IncrCounter()
        {
            Counter = Counter + 10;

        }

        private bool IncrCheck()
        {
            return Counter < 200 && StartStop == "Stop";

            if(Counter == 190)
            {
                Info = "Ralentit fi t'es au max!";
            }
            
            

        }

        private void DecrCounter()
        {
            Counter--;
            Info = "La voiture ralentit";
        }

        private bool DecrCheck()
        {
            return Counter > 0 && StartStop == "Démarrer";
        }

        private void TurnLeft()
        {
            Info = "La voiture tourne à gauche";
        }

        private void TurnRight()
        {
            Info = "La voiture tourne à droite";
        }

        private void StartToStop()
        {
            if (StartStop == "Démarrer")
            {
                StartStop = "Stop";
                Info = "La voiture démarre";
            }
            else if (StartStop == "Stop")
            {
                StartStop = "Démarrer";
                Info = "La voiture s'arrête";
            }
        }


 


    }
}
