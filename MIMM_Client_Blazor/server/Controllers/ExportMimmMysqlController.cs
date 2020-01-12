using Microsoft.AspNetCore.Mvc;
using MimmClientBlazor.Data;

namespace MimmClientBlazor
{
    public partial class ExportMimmMysqlController : ExportController
    {
        private readonly MimmMysqlContext context;

        public ExportMimmMysqlController(MimmMysqlContext context)
        {
            this.context = context;
        }

        [HttpGet("/export/MimmMysql/albums/csv")]
        public FileStreamResult ExportAlbumsToCSV()
        {
            return ToCSV(ApplyQuery(context.Albums, Request.Query));
        }

        [HttpGet("/export/MimmMysql/albums/excel")]
        public FileStreamResult ExportAlbumsToExcel()
        {
            return ToExcel(ApplyQuery(context.Albums, Request.Query));
        }

        [HttpGet("/export/MimmMysql/artists/csv")]
        public FileStreamResult ExportArtistsToCSV()
        {
            return ToCSV(ApplyQuery(context.Artists, Request.Query));
        }

        [HttpGet("/export/MimmMysql/artists/excel")]
        public FileStreamResult ExportArtistsToExcel()
        {
            return ToExcel(ApplyQuery(context.Artists, Request.Query));
        }

        [HttpGet("/export/MimmMysql/feelings/csv")]
        public FileStreamResult ExportFeelingsToCSV()
        {
            return ToCSV(ApplyQuery(context.Feelings, Request.Query));
        }

        [HttpGet("/export/MimmMysql/feelings/excel")]
        public FileStreamResult ExportFeelingsToExcel()
        {
            return ToExcel(ApplyQuery(context.Feelings, Request.Query));
        }

        [HttpGet("/export/MimmMysql/songs/csv")]
        public FileStreamResult ExportSongsToCSV()
        {
            return ToCSV(ApplyQuery(context.Songs, Request.Query));
        }

        [HttpGet("/export/MimmMysql/songs/excel")]
        public FileStreamResult ExportSongsToExcel()
        {
            return ToExcel(ApplyQuery(context.Songs, Request.Query));
        }

        [HttpGet("/export/MimmMysql/tracks/csv")]
        public FileStreamResult ExportTracksToCSV()
        {
            return ToCSV(ApplyQuery(context.Tracks, Request.Query));
        }

        [HttpGet("/export/MimmMysql/tracks/excel")]
        public FileStreamResult ExportTracksToExcel()
        {
            return ToExcel(ApplyQuery(context.Tracks, Request.Query));
        }

        [HttpGet("/export/MimmMysql/users/csv")]
        public FileStreamResult ExportUsersToCSV()
        {
            return ToCSV(ApplyQuery(context.Users, Request.Query));
        }

        [HttpGet("/export/MimmMysql/users/excel")]
        public FileStreamResult ExportUsersToExcel()
        {
            return ToExcel(ApplyQuery(context.Users, Request.Query));
        }
    }
}
