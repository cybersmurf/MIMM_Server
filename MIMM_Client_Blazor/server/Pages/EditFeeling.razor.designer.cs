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
    public partial class EditFeelingComponent : ComponentBase
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

        MimmClientBlazor.Models.MimmMysql.Feeling _feeling;
        protected MimmClientBlazor.Models.MimmMysql.Feeling feeling
        {
            get
            {
                return _feeling;
            }
            set
            {
                if(!object.Equals(_feeling, value))
                {
                    _feeling = value;
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

            var mimmMysqlGetFeelingByidResult = await MimmMysql.GetFeelingByid(int.Parse($"{id}"));
            feeling = mimmMysqlGetFeelingByidResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(MimmClientBlazor.Models.MimmMysql.Feeling args)
        {
            try
            {
                var mimmMysqlUpdateFeelingResult = await MimmMysql.UpdateFeeling(int.Parse($"{id}"), feeling);
                DialogService.Close(feeling);
            }
            catch (Exception mimmMysqlUpdateFeelingException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update Feeling");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
