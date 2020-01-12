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
    public partial class TracksComponent : ComponentBase
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

        protected RadzenGrid<MimmClientBlazor.Models.MimmMysql.Track> grid0;

        IEnumerable<MimmClientBlazor.Models.MimmMysql.Track> _getTracksResult;
        protected IEnumerable<MimmClientBlazor.Models.MimmMysql.Track> getTracksResult
        {
            get
            {
                return _getTracksResult;
            }
            set
            {
                if(!object.Equals(_getTracksResult, value))
                {
                    _getTracksResult = value;
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
            var mimmMysqlGetTracksResult = await MimmMysql.GetTracks();
            getTracksResult = mimmMysqlGetTracksResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTrack>("Add Track", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(MimmClientBlazor.Models.MimmMysql.Track args)
        {
            var result = await DialogService.OpenAsync<EditTrack>("Edit Track", new Dictionary<string, object>() { {"id", args.id} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var mimmMysqlDeleteTrackResult = await MimmMysql.DeleteTrack(data.id);
                if (mimmMysqlDeleteTrackResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception mimmMysqlDeleteTrackException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete Track");
            }
        }
    }
}
