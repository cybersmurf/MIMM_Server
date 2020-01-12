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
    public partial class AddSongComponent : ComponentBase
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

        IEnumerable<MimmClientBlazor.Models.MimmMysql.Track> _getTracksForidtracksResult;
        protected IEnumerable<MimmClientBlazor.Models.MimmMysql.Track> getTracksForidtracksResult
        {
            get
            {
                return _getTracksForidtracksResult;
            }
            set
            {
                if(!object.Equals(_getTracksForidtracksResult, value))
                {
                    _getTracksForidtracksResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        MimmClientBlazor.Models.MimmMysql.Song _song;
        protected MimmClientBlazor.Models.MimmMysql.Song song
        {
            get
            {
                return _song;
            }
            set
            {
                if(!object.Equals(_song, value))
                {
                    _song = value;
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
            getTracksForidtracksResult = mimmMysqlGetTracksResult;

            song = new MimmClientBlazor.Models.MimmMysql.Song();
        }

        protected async System.Threading.Tasks.Task Form0Submit(MimmClientBlazor.Models.MimmMysql.Song args)
        {
            try
            {
                var mimmMysqlCreateSongResult = await MimmMysql.CreateSong(song);
                DialogService.Close(song);
            }
            catch (Exception mimmMysqlCreateSongException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new Song!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
