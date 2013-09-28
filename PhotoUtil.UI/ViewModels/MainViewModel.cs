using System;
using MediaOrganizer.Core;
using MediaOrganizer.Core.Enums;
using ReactiveUI;

namespace PhotoUtil.UI.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            MovePhotos = new ReactiveCommand(this.WhenAny(x => x.Path, s => false == string.IsNullOrWhiteSpace(s.Value)));

            MovePhotos.Subscribe(param =>
                {
                    PhotoUtility.FixPhotos(Path, PhotoAction.Move);
                });
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
    }
}