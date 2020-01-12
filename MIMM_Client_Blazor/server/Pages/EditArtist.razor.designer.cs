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
    public partial class EditArtistComponent : ComponentBase
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

        MimmClientBlazor.Models.MimmMysql.Artist _artist;
        protected MimmClientBlazor.Models.MimmMysql.Artist artist
        {
            get
            {
                return _artist;
            }
            set
            {
                if(!object.Equals(_artist, value))
                {
                    _artist = value;
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

            var mimmMysqlGetArtistByidResult = await MimmMysql.GetArtistByid(int.Parse($"{id}"));
            artist = mimmMysqlGetArtistByidResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(MimmClientBlazor.Models.MimmMysql.Artist args)
        {
            try
            {
                var mimmMysqlUpdateArtistResult = await MimmMysql.UpdateArtist(int.Parse($"{id}"), artist);
                DialogService.Close(artist);
            }
            catch (Exception mimmMysqlUpdateArtistException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update Artist");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
