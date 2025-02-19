using EosWebApi.Service.Model;

namespace EosWebApi.Service;

internal class CanonService(Uri host, IAuthenticator? authenticator, string appName)
    : JsonService(host, authenticator, appName, SourceGenerationContext.Default)
{
    

    protected override string? AuthenticationTestUrl => null;



    public async Task<CcapisModel?> GetApiListAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<CcapisModel>("/ccapi", cancellationToken);
        return res;
    }


    public async Task<DeviceInformationModel?> GetDeviceInformationAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<DeviceInformationModel>("/ccapi/ver100/deviceinformation", cancellationToken);
        return res;
    }





    /*

    //public static async Task<CameraDevDescModel?> GetCameraDevDescAsync(Uri url, CancellationToken cancellationToken) => await GetCameraDevDescAsync(url.Host, cancellationToken);

    //public static async Task<CameraDevDescModel?> GetCameraDevDescAsync(string host, CancellationToken cancellationToken)
    //{
    //    Uri upnpUri = new UriBuilder("http", host, 49152, "/upnp/CameraDevDesc.xml").Uri;
    //    using HttpClient upnp = new HttpClient();

    //    string text = await upnp.GetStringAsync(upnpUri);

    //    //var serializer = new XmlSerializer(typeof(CameraDevDesc));
    //    //CameraDevDesc? cameraDevDesc = (CameraDevDesc?)serializer.Deserialize(new StringReader(text));

    //    var cameraDevDesc = text.XDeserialize<CameraDevDescModel>("root");   // Namespace="urn:schemas-upnp-org:device-1-0"
    //    return cameraDevDesc;

    //}

    #region Finder

    #endregion

    #region List of APIs

    public async Task<CcapisModel?> GetApiListAsync(CancellationToken cancellationToken)
        => await GetFromJsonAsync<CcapisModel>("/ccapi", cancellationToken);

    public async Task<CcapisModel?> GetApiListAsync(string version, CancellationToken cancellationToken)
       => await GetFromJsonAsync<CcapisModel>($"/ccapi/{version}/topurlfordev", cancellationToken);

    #endregion

    #region Camera Information (Fixed Values)

    
    #endregion

    #region Camera Status (Variable Values)

    public async Task<IEnumerable<StorageModel>?> GetDeviceStatusStorageAsync(CancellationToken cancellationToken)
        => (await GetFromJsonAsync<DeviceStatusStorageModel>("/ccapi/ver110/devicestatus/storage", cancellationToken))?.Storages;

    public async Task<DeviceStatusCurrentStorage?> GetDeviceStatusCurrentStorageAsync(CancellationToken cancellationToken)
        => await GetFromJsonAsync<DeviceStatusCurrentStorage>("/ccapi/ver110/devicestatus/currentstorage", cancellationToken);

    public async Task<DeviceStatusCurrentDirectoryModel?> GetDeviceStatusCurrentDirectoryAsync(CancellationToken cancellationToken)
        => await GetFromJsonAsync<DeviceStatusCurrentDirectoryModel>("/ccapi/ver110/devicestatus/currentdirectory", cancellationToken);

    public async Task<DeviceStatusBatteryModel?> GetDeviceStatusBatteryAsync(CancellationToken cancellationToken)
        => await GetFromJsonAsync<DeviceStatusBatteryModel>("/ccapi/ver110/devicestatus/battery", cancellationToken);

    public async Task<DeviceStatusBatteriesModel?> GetDeviceStatusBatteriesAsync(CancellationToken cancellationToken)
        => await GetFromJsonAsync<DeviceStatusBatteriesModel>("/ccapi/ver110/devicestatus/batterylist", cancellationToken);

    public async Task<LensModel?> GetDeviceStatusLensAsync(CancellationToken cancellationToken)
        => await GetFromJsonAsync<LensModel>("/ccapi/ver100/devicestatus/lens", cancellationToken);

    public async Task<TempStatusModel?> GetDeviceStatusTemperatureAsync(CancellationToken cancellationToken)
        => (await GetFromJsonAsync<TempStatusModel>("/ccapi/ver100/devicestatus/temperature", cancellationToken))?.Status;

    #endregion

    #region Camera Settings

    public async Task<string?> GetCopyrightAsync(CancellationToken cancellationToken)
        => (await GetFromJsonAsync<CameraCopyrightModel>("/ccapi/ver100/functions/registeredname/copyright", cancellationToken))?.Copyright;

    public async Task SetCopyrightAsync(string? value, CancellationToken cancellationToken)
        => await PutAsJsonAsync("/ccapi/ver100/functions/registeredname/copyright", new CameraCopyrightModel() { Copyright = value }, cancellationToken);

    public async Task<string?> GetAuthorAsync(CancellationToken cancellationToken)
        => (await GetFromJsonAsync<CameraAuthorModel>("/ccapi/ver100/functions/registeredname/author", cancellationToken))?.Author;

    public async Task SetAuthorAsync(string? value, CancellationToken cancellationToken)
        => await PutAsJsonAsync("/ccapi/ver100/functions/registeredname/author", new CameraAuthorModel() { Author = value }, cancellationToken);

    public async Task<string?> GetOwnerAsync(CancellationToken cancellationToken)
       => (await GetFromJsonAsync<CameraOwnerNameModel>("/ccapi/ver100/functions/registeredname/ownername", cancellationToken))?.OwnerName;

    public async Task SetOwnerAsync(string? value, CancellationToken cancellationToken)
        => await PutAsJsonAsync("/ccapi/ver100/functions/registeredname/ownername", new CameraOwnerNameModel() { OwnerName = value }, cancellationToken);


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
