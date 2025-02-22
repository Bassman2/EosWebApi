namespace EosWebApi.Service;

internal class CanonService : JsonService
{
    protected override string? AuthenticationTestUrl => null;

    public CanonService(Uri host, IAuthenticator? authenticator, string appName)
        : base(host, authenticator, appName, SourceGenerationContext.Default)
    {
        CcapisModel ccapi = GetApiListAsync(CancellationToken.None).Result ?? throw new Exception("No connected Canon device");
        if (ccapi.Ver140 is not null)
        {
            foreach (var ver in ccapi.Ver140)
            {
                var entry = ver.Path!.Replace(@"\", "").Split('/', 4).ToList();
                verDict[entry[3]] = entry[2];
            }
        }
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

    private readonly Dictionary<string, string> verDict = [];

    protected override async Task ErrorHandlingAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    {
        var errorMessage = await ReadFromJsonAsync<ErrorMessageModel>(response, cancellationToken); 
        throw new WebServiceException(errorMessage?.Message, response.RequestMessage?.RequestUri, response.StatusCode, response.ReasonPhrase, memberName);
    }

    private string CreateRequest(string path)
    {
        string version = verDict[path];
        return $"/ccapi/{version}/{path}";
    }

    private string CreateRequest(string path, string arg)
    {
        string version = verDict[path];
        return $"/ccapi/{version}/{path}/{arg}";
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

    public async Task<DateTimeDstModel?> GetDateTimeAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<DateTimeDstModel>(CreateRequest("functions/datetime"), cancellationToken);
        return res;
    }

    public async Task SetDateTimeAsync(DateTimeDstModel value, CancellationToken cancellationToken)
    {
        await PutAsJsonAsync(CreateRequest("functions/datetime"), value, cancellationToken);
    }

    public async Task FormatAsync(string cardName, CancellationToken cancellationToken)
    {
        await PostAsJsonAsync(CreateRequest("functions/cardformat"), new StorageNameModel() { Name = cardName }, cancellationToken);
    }

    public async Task<ValueAbilityModel?> GetBeepAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<ValueAbilityModel>(CreateRequest("functions/beep"), cancellationToken);
        return res;
    }

    public async Task SetBeepAsync(ValueAbilityModel value, CancellationToken cancellationToken)
    {
        await PutAsJsonAsync(CreateRequest("functions/beep"), value, cancellationToken);
    }

    public async Task<ValueAbilityModel?> GetDisplayOffAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<ValueAbilityModel>(CreateRequest("functions/displayoff"), cancellationToken);
        return res;
    }

    public async Task SetDisplayOffAsync(ValueAbilityModel value, CancellationToken cancellationToken)
    { 
        await PutAsJsonAsync(CreateRequest("functions/displayoff"), value, cancellationToken);
    }

    public async Task<ValueAbilityModel?> GetAutoPowerOffAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<ValueAbilityModel>(CreateRequest("functions/autopoweroff"), cancellationToken);
        return res;
    }

    public async Task SetAutoPowerOffAsync(ValueAbilityModel value, CancellationToken cancellationToken)
    {
        await PutAsJsonAsync(CreateRequest("functions/autopoweroff"), value, cancellationToken);
    }

    public async Task SensorCleaningAsync(SensorCleaningModel sensorCleaningModel, CancellationToken cancellationToken)
    {
        await PostAsJsonAsync(CreateRequest("functions/sensorcleaning"), sensorCleaningModel, cancellationToken);
    }

    public async Task NetworkConnectionAsync(NetworkConnectionModel networkConnectionModel, CancellationToken cancellationToken)
    {
        await PostAsJsonAsync(CreateRequest("functions/networkconnection"), networkConnectionModel, cancellationToken);
    }

    //public async Task<NetworkSettingModel?> GetNetworkSettingAsync(SensorCleaningModel sensorCleaningModel, CancellationToken cancellationToken)
    //{
    //    var res = await GetFromJsonAsync<NetworkSettingModel>(CreateRequest("functions/networksetting"), cancellationToken);
    //    return res;
    //}

    #region Contents Operations

    public async Task<ContentsModel?> GetContentsAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<ContentsModel>(CreateRequest("contents"), cancellationToken);
        return res;
    }

    public async Task<ContentsModel?> GetDirectoriesAsync(string storage, CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<ContentsModel>(CreateRequest("contents", storage), cancellationToken);
        return res;
    }

    public async IAsyncEnumerable<string> GetFilesAsync(string storage, string directory, FileType type, Order order, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string baseReq = CombineUrl(CreateRequest("contents"), storage, directory, ("type", type), ("kind", "chunked"), ("order", order));

        int page = 1;
        do
        {
            string req = CombineUrl(baseReq, ("page", page));

            var res = await GetFromJsonAsync<ContentsModel>(req, cancellationToken);
            foreach (var item in res!.Path!)
            {
                yield return item;
            }
        } while (true);
    }

    public async Task DeleteDirectoryAsync(string storage, string directory, CancellationToken cancellationToken)
    {
        await DeleteAsync(CreateRequest("contents", $"/{storage}/{directory}"), cancellationToken);
    }

    public async Task<FileModel?> GetFileAsync(string storage, string directory, string file, CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<FileModel>(CombineUrl(CreateRequest("contents"), storage, directory, file, ("kind", "info")), cancellationToken);
        return res;
    }

    public async Task ModifyFileAsync(string storage, string directory, string file, Action action, string value, CancellationToken cancellationToken)
    {
        await PutAsJsonAsync(CombineUrl(CreateRequest("contents"), storage, directory, file), new ActionModel() { Action = action, Value = value }, cancellationToken);
    }

    public async Task DeleteFileAsync(string storage, string directory, string file, CancellationToken cancellationToken)
    {
        await DeleteAsync(CombineUrl(CreateRequest("contents"), storage, directory, file), cancellationToken);
    }

    public async Task<Stream?> DownloadFileAsync(string storage, string directory, string file, Kind kind, CancellationToken cancellationToken)
    {
        return await GetFromStreamAsync(CombineUrl(CreateRequest("contents"), storage, directory, file, ("kind", kind)), cancellationToken);
    }

    #endregion
}
