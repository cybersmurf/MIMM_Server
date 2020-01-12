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
    public partial class UsersComponent : ComponentBase
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

        protected RadzenGrid<MimmClientBlazor.Models.MimmMysql.User> grid0;

        IEnumerable<MimmClientBlazor.Models.MimmMysql.User> _getUsersResult;
        protected IEnumerable<MimmClientBlazor.Models.MimmMysql.User> getUsersResult
        {
            get
            {
                return _getUsersResult;
            }
            set
            {
                if(!object.Equals(_getUsersResult, value))
                {
                    _getUsersResult = value;
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
            var mimmMysqlGetUsersResult = await MimmMysql.GetUsers();
            getUsersResult = mimmMysqlGetUsersResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddUser>("Add User", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(MimmClientBlazor.Models.MimmMysql.User args)
        {
            var result = await DialogService.OpenAsync<EditUser>("Edit User", new Dictionary<string, object>() { {"email", args.email} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var mimmMysqlDeleteUserResult = await MimmMysql.DeleteUser($"{data.email}");
                if (mimmMysqlDeleteUserResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception mimmMysqlDeleteUserException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete User");
            }
        }
    }
}
