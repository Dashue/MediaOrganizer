using ReactiveUI;
using System;
using System.Threading;

namespace PhotoUtil.UI.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            MovePhotos = new ReactiveCommand(
                this.WhenAny(x => x.Path, s => false == string.IsNullOrWhiteSpace(s.Value)));

            MovePhotos.ThrownExceptions.Subscribe(exception =>
            {
                Status = exception.Message;
            });

            MovePhotos.RegisterAsyncAction(_ =>
            {
                var start = DateTime.Now;
                //PhotoUtility.FixPhotos(Path, PhotoAction.Move);
                Thread.Sleep(5000);
                var end = DateTime.Now;

                Status = ((int)(end - start).TotalSeconds).ToString() + " Seconds";
            }).Subscribe();
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                this.RaiseAndSetIfChanged(ref _path, value);
            }
        }

        public ReactiveCommand MovePhotos { get; set; }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { this.RaiseAndSetIfChanged(ref _status, value); }
        }
    }
}