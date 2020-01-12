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
    public partial class AlbumsComponent : ComponentBase
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

        protected RadzenGrid<MimmClientBlazor.Models.MimmMysql.Album> grid0;

        IEnumerable<MimmClientBlazor.Models.MimmMysql.Album> _getAlbumsResult;
        protected IEnumerable<MimmClientBlazor.Models.MimmMysql.Album> getAlbumsResult
        {
            get
            {
                return _getAlbumsResult;
            }
            set
            {
                if(!object.Equals(_getAlbumsResult, value))
                {
                    _getAlbumsResult = value;
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
            var mimmMysqlGetAlbumsResult = await MimmMysql.GetAlbums();
            getAlbumsResult = mimmMysqlGetAlbumsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddAlbum>("Add Album", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(MimmClientBlazor.Models.MimmMysql.Album args)
        {
            var result = await DialogService.OpenAsync<EditAlbum>("Edit Album", new Dictionary<string, object>() { {"id", args.id} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var mimmMysqlDeleteAlbumResult = await MimmMysql.DeleteAlbum(data.id);
                if (mimmMysqlDeleteAlbumResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception mimmMysqlDeleteAlbumException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete Album");
            }
        }
    }
}
