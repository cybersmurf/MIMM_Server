using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using MimmClientBlazor.Models.MimmApi;
using MimmClientBlazor.Models.MimmMysql;
using Microsoft.EntityFrameworkCore;

namespace MimmClientBlazor.Pages
{
    public partial class ArtistsComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected MimmApiService MimmApi { get; set; }

        [Inject]
        protected MimmMysqlService MimmMysql { get; set; }

        protected RadzenGrid<MimmClientBlazor.Models.MimmMysql.Artist> grid0;

        IEnumerable<MimmClientBlazor.Models.MimmMysql.Artist> _getArtistsResult;
        protected IEnumerable<MimmClientBlazor.Models.MimmMysql.Artist> getArtistsResult
        {
            get
            {
                return _getArtistsResult;
            }
            set
            {
                if(!object.Equals(_getArtistsResult, value))
                {
                    _getArtistsResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }

        protected async System.Threading.Tasks.Task Load()
        {
            var mimmMysqlGetArtistsResult = await MimmMysql.GetArtists();
            getArtistsResult = mimmMysqlGetArtistsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddArtist>("Add Artist", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(MimmClientBlazor.Models.MimmMysql.Artist args)
        {
            var result = await DialogService.OpenAsync<EditArtist>("Edit Artist", new Dictionary<string, object>() { {"id", args.id} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var mimmMysqlDeleteArtistResult = await MimmMysql.DeleteArtist(data.id);
                if (mimmMysqlDeleteArtistResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception mimmMysqlDeleteArtistException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete Artist");
            }
        }
    }
}
