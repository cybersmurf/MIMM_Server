﻿using System;
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
    public partial class FeelingsComponent : ComponentBase
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

        protected RadzenGrid<MimmClientBlazor.Models.MimmMysql.Feeling> grid0;

        IEnumerable<MimmClientBlazor.Models.MimmMysql.Feeling> _getFeelingsResult;
        protected IEnumerable<MimmClientBlazor.Models.MimmMysql.Feeling> getFeelingsResult
        {
            get
            {
                return _getFeelingsResult;
            }
            set
            {
                if(!object.Equals(_getFeelingsResult, value))
                {
                    _getFeelingsResult = value;
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
            var mimmMysqlGetFeelingsResult = await MimmMysql.GetFeelings();
            getFeelingsResult = mimmMysqlGetFeelingsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddFeeling>("Add Feeling", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(MimmClientBlazor.Models.MimmMysql.Feeling args)
        {
            var result = await DialogService.OpenAsync<EditFeeling>("Edit Feeling", new Dictionary<string, object>() { {"id", args.id} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var mimmMysqlDeleteFeelingResult = await MimmMysql.DeleteFeeling(data.id);
                if (mimmMysqlDeleteFeelingResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception mimmMysqlDeleteFeelingException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete Feeling");
            }
        }
    }
}
