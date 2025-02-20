using EosWebApi.Service.Model;

namespace EosWebApi.Service;

internal class CanonService : JsonService
{
    protected override string? AuthenticationTestUrl => null;

    public CanonService(Uri host, IAuthenticator? authenticator, string appName)
        : base(host, authenticator, appName, SourceGenerationContext.Default)
    {
        CcapisModel ccapi = GetApiListAsync(CancellationToken.None).Result ?? throw new Exception("No connected Canon device");
        if (ccapi.Ver130 is not null)
        {
            foreach (var ver in ccapi.Ver130)
            {
                var entry = ver.Path!.Replace(@"\", "").Split('/', 4).ToList();
                verDict[entry[3]] = entry[2];
            }
        }
        if (ccapi.Ver120 is not null)
        {
            foreach (var ver in ccapi.Ver120)
            {
                var entry = ver.Path!.Replace(@"\", "").Split('/', 4).ToList();
                verDict[entry[3]] = entry[2];
            }
        }
        if (ccapi.Ver110 is not null)
        {
            foreach (var ver in ccapi.Ver110)
            {
                var entry = ver.Path!.Replace(@"\", "").Split('/', 4).ToList();
                verDict[entry[3]] = entry[2];
            }
        }
        if (ccapi.Ver100 is not null)
        {
            foreach (var ver in ccapi.Ver100)
            {
                var entry = ver.Path!.Replace(@"\", "").Split('/', 4).ToList();
                verDict[entry[3]] = entry[2];
            }
        }
    }

    private Dictionary<string, string> verDict = [];

    private string CreateRequest(string path)
    {
        string version = verDict[path];
        return $"/ccapi/{version}/{path}";
    }       

    private async Task<CcapisModel?> GetApiListAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<CcapisModel>("/ccapi", cancellationToken);
        return res;
    }


    public async Task<DeviceInformationModel?> GetDeviceInformationAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<DeviceInformationModel>(CreateRequest("deviceinformation"), cancellationToken);
        return res;
    }

    public async Task<List<StorageModel>?> GetStoragesAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<DeviceStatusStorageModel>(CreateRequest("devicestatus/storage"), cancellationToken);
        return res?.Storages;
    }

    public async Task<CurrentStorageModel?> GetCurrentStorageAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<CurrentStorageModel>(CreateRequest("devicestatus/currentstorage"), cancellationToken);
        return res;
    }

    public async Task<CurrentDirectoryModel?> GetCurrentDirectoryAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<CurrentDirectoryModel>(CreateRequest("devicestatus/currentdirectory"), cancellationToken);
        return res;
    }

    public async Task<BatteryModel?> GetBatteryAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<BatteryModel>(CreateRequest("devicestatus/battery"), cancellationToken);
        return res;
    }

    public async Task<List<BatteryModel>?> GetBatteriesAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<BatteryListModel>(CreateRequest("devicestatus/batterylist"), cancellationToken);
        return res?.Batteries;
    }

    public async Task<LensModel?> GetLensAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<LensModel>(CreateRequest("devicestatus/lens"), cancellationToken);
        return res;
    }

    public async Task<TemperatureModel?> GetTemperatureAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<TemperatureModel>(CreateRequest("devicestatus/temperature"), cancellationToken);
        return res;
    }

    public async Task<PowerZoomStatusModel?> GetPowerZoomStatusAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<PowerZoomStatusModel>(CreateRequest("devicestatus/powerzoomstatus"), cancellationToken);
        return res;
    }

    public async Task<string?> GetCopyrightAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<CopyrightModel>(CreateRequest("functions/registeredname/copyright"), cancellationToken);
        return res?.Copyright;
    }

    public async Task SetCopyrightAsync(string? copyright, CancellationToken cancellationToken)
    {
        await PutAsJsonAsync(CreateRequest("functions/registeredname/copyright"), new CopyrightModel() { Copyright = copyright }, cancellationToken);
    }

    public async Task DeleteCopyrightAsync( CancellationToken cancellationToken)
    {
        await DeleteAsync(CreateRequest("functions/registeredname/copyright"), cancellationToken);
    }

    public async Task<string?> GetAuthorAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<AuthorModel>(CreateRequest("functions/registeredname/author"), cancellationToken);
        return res?.Author;
    }

    public async Task SetAuthorAsync(string? author, CancellationToken cancellationToken)
    {
        await PutAsJsonAsync(CreateRequest("functions/registeredname/author"), new AuthorModel() { Author = author }, cancellationToken);
    }

    public async Task DeleteAuthorAsync(CancellationToken cancellationToken)
    {
        await DeleteAsync(CreateRequest("functions/registeredname/author"), cancellationToken);
    }

    public async Task<string?> GetOwnerNameAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<OwnerNameModel>(CreateRequest("functions/registeredname/ownername"), cancellationToken);
        return res?.OwnerName;
    }

    public async Task SetOwnerNameAsync(string? ownerName, CancellationToken cancellationToken)
    {
        await PutAsJsonAsync(CreateRequest("functions/registeredname/ownername"), new OwnerNameModel() { OwnerName = ownerName }, cancellationToken);
    }

    public async Task DeleteOwnerNameAsync(CancellationToken cancellationToken)
    {
        await DeleteAsync(CreateRequest("functions/registeredname/ownername"), cancellationToken);
    }

    public async Task<string?> GetNicknameAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<NicknameModel>(CreateRequest("functions/registeredname/nickname"), cancellationToken);
        return res?.Nickname;
    }

    public async Task SetNicknameAsync(string nickname, CancellationToken cancellationToken)
    {
        await PutAsJsonAsync(CreateRequest("functions/registeredname/nickname"), new NicknameModel() { Nickname = nickname }, cancellationToken);
    }

    public async Task DeleteNicknameAsync(CancellationToken cancellationToken)
    {
        await DeleteAsync(CreateRequest("functions/registeredname/nickname"), cancellationToken);
    }



    /*


    
    

    #region Camera Settings

   

    public async Task<string?> GetNicknameAsync(CancellationToken cancellationToken)
       => (await GetFromJsonAsync<CameraNicknameModel>("/ccapi/ver100/functions/registeredname/nickname", cancellationToken))?.Nickname;

    public async Task SetNicknameAsync(string? value, CancellationToken cancellationToken)
        => await PutAsJsonAsync("/ccapi/ver100/functions/registeredname/nickname", new CameraNicknameModel() { Nickname = value }, cancellationToken);

    public async Task<DateTime?> GetDateTimeAsync(CancellationToken cancellationToken)
       => (await GetFromJsonAsync<CameraDateTimeModel>("/ccapi/ver100/functions/datetime", cancellationToken))?.DateTime;

    public async Task SetDateTimeAsync(DateTime? value, CancellationToken cancellationToken)
       => await PutAsJsonAsync("/ccapi/ver100/functions/datetime", (CameraDateTimeModel?)value, cancellationToken);


    public async Task<ValueAbilityModel?> GetBeepAsync(CancellationToken cancellationToken)
        => await GetFromJsonAsync<ValueAbilityModel>("/ccapi/ver100/functions/beep", cancellationToken);

    public async Task SetBeepAsync(string value, CancellationToken cancellationToken) 
        => await PutAsJsonAsync("/ccapi/ver100/functions/beep", new ValueAbilityModel() { Value = value }, cancellationToken);

    public async Task<ValueAbilityModel?> GetDisplayOffAsync(CancellationToken cancellationToken)
        => await GetFromJsonAsync<ValueAbilityModel>("/ccapi/ver100/functions/displayoff", cancellationToken);

    public async Task SetDisplayOffAsync(string value, CancellationToken cancellationToken)
        => await PutAsJsonAsync("/ccapi/ver100/functions/displayoff", new ValueAbilityModel() { Value = value }, cancellationToken);

    public async Task<ValueAbilityModel?> GetAutoPowerOffAsync(CancellationToken cancellationToken) 
        => await GetFromJsonAsync<ValueAbilityModel>("/ccapi/ver100/functions/autopoweroff", cancellationToken);

    public async Task SetAutoPowerOffAsync(string? value, CancellationToken cancellationToken) 
        => await PutAsJsonAsync("/ccapi/ver100/functions/autopoweroff", new ValueAbilityModel() { Value = value }, cancellationToken);

    public async Task FormatAsync(string card, CancellationToken cancellationToken)
       => await PostAsJsonAsync("/ccapi/ver100/functions/cardformat", new StorageNameModel() { Name = card }, cancellationToken);

    //public ValueGet? GetMute()
    //   => GetFromJson<ValueGet>("/ccapi/ver100/functions/beep");

    //public ValuePut? SetMute(string value)
    //   => PutAsJson<ValuePut>("/ccapi/ver100/functions/beep", new ValuePut { Value = value });

    #endregion

    #region Image Operations

    public async Task<IEnumerable<string>?> GetVolumnsAsync(CancellationToken cancellationToken)
        => (await GetFromJsonAsync<PathListModel>("/ccapi/ver120/contents", cancellationToken))?.Paths;

    public async Task<IEnumerable<string>?> GetDirectoriesAsync(string volumeName, CancellationToken cancellationToken)
        => (await GetFromJsonAsync<PathListModel>($"/ccapi/ver120/contents/{volumeName}", cancellationToken))?.Paths;

    public async Task<bool> HasFiles(string volumeName, string directoryName, CancellationToken cancellationToken)
    {
        return (await GetFromJsonAsync<Number>($"/ccapi/ver120/contents/{volumeName}/{directoryName}?type=all&kind=number", cancellationToken))?.ContentsNumber > 0;
    }
    
    public async IAsyncEnumerable<string> GetFilesAsync(string volumeName, string directoryName, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        Number? number = await GetFromJsonAsync<Number>($"/ccapi/ver120/contents/{volumeName}/{directoryName}?type=all&kind=number", cancellationToken);
        for (uint page = 1; page <= number!.PageNumber; page++)
        {
            var list = (await GetFromJsonAsync<PathListModel>($"/ccapi/ver120/contents/{volumeName}/{directoryName}?type=all&kind=list&page={page}", cancellationToken))?.Paths;
            foreach (var path in list!)
            {
                yield return path;
            }
        }
    }

    public async Task DeleteDirectory(string volumeName, string directoryName, CancellationToken cancellationToken)
        => await DeleteAsync($"/ccapi/ver130/contents/{volumeName}/{directoryName}", cancellationToken);

    public async Task<Stream?> DownloadImageAsync(string volumeName, string directoryName, string fileName, CancellationToken cancellationToken)
       => await GetFromStreamAsync($"/ccapi/ver130/contents/{volumeName}/{directoryName}/{fileName}?kind=main", cancellationToken);

    public async Task<Stream?> DownloadThumbnailAsync(string volumeName, string directoryName, string fileName, CancellationToken cancellationToken)
        => await GetFromStreamAsync($"/ccapi/ver130/contents/{volumeName}/{directoryName}/{fileName}?kind=thumbnail", cancellationToken);

    public async Task<Stream?> DownloadDisplayAsync(string volumeName, string directoryName, string fileName, CancellationToken cancellationToken)
        => await GetFromStreamAsync($"/ccapi/ver130/contents/{volumeName}/{directoryName}/{fileName}?kind=display", cancellationToken);

    public async Task<Stream?> DownloadEmbeddedAsync(string volumeName, string directoryName, string fileName, CancellationToken cancellationToken)
        => await GetFromStreamAsync($"/ccapi/ver130/contents/{volumeName}/{directoryName}/{fileName}?kind=embedded", cancellationToken);

    public async Task<ImageInfoModel?> GetFileInfoAsync(string volumeName, string directoryName, string fileName, CancellationToken cancellationToken)
        => await GetFromJsonAsync<ImageInfoModel>($"/ccapi/ver130/contents/{volumeName}/{directoryName}/{fileName}?kind=info", cancellationToken);

    #endregion

    #region Shooting Control

    #endregion

    */
}
