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
    public partial class AddUserComponent : ComponentBase
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

        MimmClientBlazor.Models.MimmMysql.User _user;
        protected MimmClientBlazor.Models.MimmMysql.User user
        {
            get
            {
                return _user;
            }
            set
            {
                if(!object.Equals(_user, value))
                {
                    _user = value;
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
            user = new MimmClientBlazor.Models.MimmMysql.User();
        }

        protected async System.Threading.Tasks.Task Form0Submit(MimmClientBlazor.Models.MimmMysql.User args)
        {
            try
            {
                var mimmMysqlCreateUserResult = await MimmMysql.CreateUser(user);
                DialogService.Close(user);
            }
            catch (Exception mimmMysqlCreateUserException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new User!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
