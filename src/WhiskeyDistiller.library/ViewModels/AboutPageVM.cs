using System.ComponentModel;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class AboutPageVM : BaseVM
    {
        private int yPosition = 500;

        private string _creditsMargin;

        public string CreditsMargin { get { return _creditsMargin; } set { _creditsMargin = value; OnPropertyChanged("CreditsMargin"); } }

        private BackgroundWorker _bgWorker;

        public AboutPageVM(INavigation navigation) : base(navigation)
        {
            _bgWorker = new BackgroundWorker();
            _bgWorker.RunWorkerCompleted += _bgWorker_RunWorkerCompleted;
            _bgWorker.RunWorkerAsync();
        }

        private void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CreditsMargin = $"0,{yPosition},0,0";

            yPosition -= 10;

            System.Threading.Tasks.Task.Delay(500);

            _bgWorker.RunWorkerAsync();
        }
    }
}