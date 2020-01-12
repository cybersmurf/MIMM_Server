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
    public partial class EditAlbumComponent : ComponentBase
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

        [Parameter]
        public dynamic id { get; set; }

        bool _canEdit;
        protected bool canEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                if(!object.Equals(_canEdit, value))
                {
                    _canEdit = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        MimmClientBlazor.Models.MimmMysql.Album _album;
        protected MimmClientBlazor.Models.MimmMysql.Album album
        {
            get
            {
                return _album;
            }
            set
            {
                if(!object.Equals(_album, value))
                {
                    _album = value;
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
            canEdit = true;

            var mimmMysqlGetAlbumByidResult = await MimmMysql.GetAlbumByid(int.Parse($"{id}"));
            album = mimmMysqlGetAlbumByidResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(MimmClientBlazor.Models.MimmMysql.Album args)
        {
            try
            {
                var mimmMysqlUpdateAlbumResult = await MimmMysql.UpdateAlbum(int.Parse($"{id}"), album);
                DialogService.Close(album);
            }
            catch (Exception mimmMysqlUpdateAlbumException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update Album");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
