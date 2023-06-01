using System;
using System.ComponentModel;

namespace wanderconnect_android.Models.Location
{
    public class TopPick : INotifyPropertyChanged
    {
        string _photoUrl;
        public string PhotoUrl
        {
            get => _photoUrl;
            set
            {
                if (_photoUrl == value)
                    return;

                _photoUrl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhotoUrl)));
            }
        }

        string _locationName;
        public string LocationName
        {
            get => _locationName;
            set
            {
                if (_locationName == value)
                    return;

                _locationName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationName)));
            }
        }

        string _locationAddress;
        public string LocationAddress
        {
            get => _locationAddress;
            set
            {
                if (_locationAddress == value)
                    return;

                _locationAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationAddress)));
            }
        }

        string _locationType;
        public string LocationType
        {
            get => _locationType;
            set
            {
                if (_locationType == value)
                    return;

                _locationType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationType)));
            }
        }

        string _starRating;
        public string StarRating
        {
            get => _starRating;
            set
            {
                if (_starRating == value)
                    return;

                _starRating = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StarRating)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

