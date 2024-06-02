using System.Collections.ObjectModel;
using System.Windows.Input;
using Assignment.Application.Common.Interfaces;
using Assignment.Application.Country.Queries.GetCountryCollection;
using Caliburn.Micro;
using MediatR;

namespace Assignment.UI;
internal class WeatherForecastViewModel : Screen
{
    private readonly ISender _sender;
    private readonly IWindowManager _windowManager;
    private readonly IWeatherForecastApi _weatherForecastApi;

    private IList<CountryDto> _countryCollection;
    public IList<CountryDto> CountryCollection
    {
        get
        {
            return _countryCollection;
        }
        set
        {
            _countryCollection = value;
            NotifyOfPropertyChange(() => CountryCollection);
        }
    }

    private CountryDto _selectedCountry;
    public CountryDto SelectedCountry
    {
        get => _selectedCountry;
        set
        {
            _selectedCountry = value;
            NotifyOfPropertyChange(() => SelectedCountry);
            NotifyOfPropertyChange(() => CityCollection);
        }
    }


    public IList<CityDto> CityCollection => SelectedCountry?.CityCollection;


    private CityDto _selectedCity;
    public CityDto SelectedCity
    {
        get => _selectedCity;
        set
        {
            _selectedCity = value;

            NotifyOfPropertyChange(() => SelectedCity);
            if(SelectedCity?.Name is not null)
                CityTemperature = _weatherForecastApi.GetTemperature(SelectedCity.Name,DateTime.Now);
        }
    }
    private int _cityTemperature;
    public int CityTemperature
    {
        get => _cityTemperature;
        set
        {
            _cityTemperature = value;
            NotifyOfPropertyChange(() => CityTemperature);
        }
    }
    public ICommand CloseCommand { get; }


    public WeatherForecastViewModel(ISender sender,
                                    IWindowManager windowManager,
                                    IWeatherForecastApi weatherForecastApi)
    {
        _sender = sender;
        _windowManager = windowManager;
        _weatherForecastApi = weatherForecastApi;
        CloseCommand = new RelayCommand(CloseExecute);
        Initialize();
    }

    private async void Initialize() =>
        await RefereshCountryList();

    private async Task RefereshCountryList()
    {
        var selectedCountryId = SelectedCountry?.Id;

        CountryCollection = new ObservableCollection<CountryDto>(await _sender.Send(new GetCountryCollectionQuery()));

        if (selectedCountryId.HasValue && selectedCountryId.Value > 0)
        {
            SelectedCountry = CountryCollection.FirstOrDefault(list => list.Id == selectedCountryId.Value);
        }
    }
    private async void CloseExecute(object parameter) =>
        await TryCloseAsync(false);
}
