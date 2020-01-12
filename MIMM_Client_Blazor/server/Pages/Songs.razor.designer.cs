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
    public partial class SongsComponent : ComponentBase
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

        protected RadzenGrid<MimmClientBlazor.Models.MimmMysql.Song> grid0;

        IEnumerable<MimmClientBlazor.Models.MimmMysql.Song> _getSongsResult;
        protected IEnumerable<MimmClientBlazor.Models.MimmMysql.Song> getSongsResult
        {
            get
            {
                return _getSongsResult;
            }
            set
            {
                if(!object.Equals(_getSongsResult, value))
                {
                    _getSongsResult = value;
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
            var mimmMysqlGetSongsResult = await MimmMysql.GetSongs();
            getSongsResult = mimmMysqlGetSongsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddSong>("Add Song", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(MimmClientBlazor.Models.MimmMysql.Song args)
        {
            var result = await DialogService.OpenAsync<EditSong>("Edit Song", new Dictionary<string, object>() { {"id", args.id} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var mimmMysqlDeleteSongResult = await MimmMysql.DeleteSong(data.id);
                if (mimmMysqlDeleteSongResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception mimmMysqlDeleteSongException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete Song");
            }
        }
    }
}
