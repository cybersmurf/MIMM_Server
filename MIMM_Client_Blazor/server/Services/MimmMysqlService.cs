using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using MimmClientBlazor.Data;

namespace MimmClientBlazor
{
    public partial class MimmMysqlService
    {
        private readonly MimmMysqlContext context;
        private readonly NavigationManager navigationManager;

        public MimmMysqlService(MimmMysqlContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

                public async Task ExportAlbumsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/albums/excel") : "export/mimmmysql/albums/excel", true);
        }

        public async Task ExportAlbumsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/albums/csv") : "export/mimmmysql/albums/csv", true);
        }

        partial void OnAlbumsRead(ref IQueryable<Models.MimmMysql.Album> items);

        public async Task<IQueryable<Models.MimmMysql.Album>> GetAlbums(Query query = null)
        {
            var items = context.Albums.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAlbumsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAlbumCreated(Models.MimmMysql.Album item);

        public async Task<Models.MimmMysql.Album> CreateAlbum(Models.MimmMysql.Album album)
        {
            OnAlbumCreated(album);

            context.Albums.Add(album);
            context.SaveChanges();

            return album;
        }
            public async Task ExportArtistsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/artists/excel") : "export/mimmmysql/artists/excel", true);
        }

        public async Task ExportArtistsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/artists/csv") : "export/mimmmysql/artists/csv", true);
        }

        partial void OnArtistsRead(ref IQueryable<Models.MimmMysql.Artist> items);

        public async Task<IQueryable<Models.MimmMysql.Artist>> GetArtists(Query query = null)
        {
            var items = context.Artists.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnArtistsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnArtistCreated(Models.MimmMysql.Artist item);

        public async Task<Models.MimmMysql.Artist> CreateArtist(Models.MimmMysql.Artist artist)
        {
            OnArtistCreated(artist);

            context.Artists.Add(artist);
            context.SaveChanges();

            return artist;
        }
            public async Task ExportFeelingsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/feelings/excel") : "export/mimmmysql/feelings/excel", true);
        }

        public async Task ExportFeelingsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/feelings/csv") : "export/mimmmysql/feelings/csv", true);
        }

        partial void OnFeelingsRead(ref IQueryable<Models.MimmMysql.Feeling> items);

        public async Task<IQueryable<Models.MimmMysql.Feeling>> GetFeelings(Query query = null)
        {
            var items = context.Feelings.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnFeelingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFeelingCreated(Models.MimmMysql.Feeling item);

        public async Task<Models.MimmMysql.Feeling> CreateFeeling(Models.MimmMysql.Feeling feeling)
        {
            OnFeelingCreated(feeling);

            context.Feelings.Add(feeling);
            context.SaveChanges();

            return feeling;
        }
            public async Task ExportSongsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/songs/excel") : "export/mimmmysql/songs/excel", true);
        }

        public async Task ExportSongsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/songs/csv") : "export/mimmmysql/songs/csv", true);
        }

        partial void OnSongsRead(ref IQueryable<Models.MimmMysql.Song> items);

        public async Task<IQueryable<Models.MimmMysql.Song>> GetSongs(Query query = null)
        {
            var items = context.Songs.AsQueryable();

            items = items.Include(i => i.Track);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSongsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSongCreated(Models.MimmMysql.Song item);

        public async Task<Models.MimmMysql.Song> CreateSong(Models.MimmMysql.Song song)
        {
            OnSongCreated(song);

            context.Songs.Add(song);
            context.SaveChanges();

            return song;
        }
            public async Task ExportTracksToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/tracks/excel") : "export/mimmmysql/tracks/excel", true);
        }

        public async Task ExportTracksToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/tracks/csv") : "export/mimmmysql/tracks/csv", true);
        }

        partial void OnTracksRead(ref IQueryable<Models.MimmMysql.Track> items);

        public async Task<IQueryable<Models.MimmMysql.Track>> GetTracks(Query query = null)
        {
            var items = context.Tracks.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTracksRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTrackCreated(Models.MimmMysql.Track item);

        public async Task<Models.MimmMysql.Track> CreateTrack(Models.MimmMysql.Track track)
        {
            OnTrackCreated(track);

            context.Tracks.Add(track);
            context.SaveChanges();

            return track;
        }
            public async Task ExportUsersToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/users/excel") : "export/mimmmysql/users/excel", true);
        }

        public async Task ExportUsersToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/mimmmysql/users/csv") : "export/mimmmysql/users/csv", true);
        }

        partial void OnUsersRead(ref IQueryable<Models.MimmMysql.User> items);

        public async Task<IQueryable<Models.MimmMysql.User>> GetUsers(Query query = null)
        {
            var items = context.Users.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnUsersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnUserCreated(Models.MimmMysql.User item);

        public async Task<Models.MimmMysql.User> CreateUser(Models.MimmMysql.User user)
        {
            OnUserCreated(user);

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }
    
        partial void OnAlbumDeleted(Models.MimmMysql.Album item);

        public async Task<Models.MimmMysql.Album> DeleteAlbum(int? id)
        {
            var item = context.Albums
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            OnAlbumDeleted(item);

            context.Albums.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnAlbumGet(Models.MimmMysql.Album item);

        public async Task<Models.MimmMysql.Album> GetAlbumByid(int? id)
        {
            var items = context.Albums
                              .AsNoTracking()
                              .Where(i => i.id == id);

            var item = items.FirstOrDefault();

            OnAlbumGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.MimmMysql.Album> CancelAlbumChanges(Models.MimmMysql.Album item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnAlbumUpdated(Models.MimmMysql.Album item);

        public async Task<Models.MimmMysql.Album> UpdateAlbum(int? id, Models.MimmMysql.Album album)
        {
            OnAlbumUpdated(album);

            var item = context.Albums
                              .Where(i => i.id == id)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(album);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return album;
        }
    
        partial void OnArtistDeleted(Models.MimmMysql.Artist item);

        public async Task<Models.MimmMysql.Artist> DeleteArtist(int? id)
        {
            var item = context.Artists
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            OnArtistDeleted(item);

            context.Artists.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnArtistGet(Models.MimmMysql.Artist item);

        public async Task<Models.MimmMysql.Artist> GetArtistByid(int? id)
        {
            var items = context.Artists
                              .AsNoTracking()
                              .Where(i => i.id == id);

            var item = items.FirstOrDefault();

            OnArtistGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.MimmMysql.Artist> CancelArtistChanges(Models.MimmMysql.Artist item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnArtistUpdated(Models.MimmMysql.Artist item);

        public async Task<Models.MimmMysql.Artist> UpdateArtist(int? id, Models.MimmMysql.Artist artist)
        {
            OnArtistUpdated(artist);

            var item = context.Artists
                              .Where(i => i.id == id)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(artist);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return artist;
        }
    
        partial void OnFeelingDeleted(Models.MimmMysql.Feeling item);

        public async Task<Models.MimmMysql.Feeling> DeleteFeeling(int? id)
        {
            var item = context.Feelings
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            OnFeelingDeleted(item);

            context.Feelings.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnFeelingGet(Models.MimmMysql.Feeling item);

        public async Task<Models.MimmMysql.Feeling> GetFeelingByid(int? id)
        {
            var items = context.Feelings
                              .AsNoTracking()
                              .Where(i => i.id == id);

            var item = items.FirstOrDefault();

            OnFeelingGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.MimmMysql.Feeling> CancelFeelingChanges(Models.MimmMysql.Feeling item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnFeelingUpdated(Models.MimmMysql.Feeling item);

        public async Task<Models.MimmMysql.Feeling> UpdateFeeling(int? id, Models.MimmMysql.Feeling feeling)
        {
            OnFeelingUpdated(feeling);

            var item = context.Feelings
                              .Where(i => i.id == id)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(feeling);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return feeling;
        }
    
        partial void OnSongDeleted(Models.MimmMysql.Song item);

        public async Task<Models.MimmMysql.Song> DeleteSong(int? id)
        {
            var item = context.Songs
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            OnSongDeleted(item);

            context.Songs.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnSongGet(Models.MimmMysql.Song item);

        public async Task<Models.MimmMysql.Song> GetSongByid(int? id)
        {
            var items = context.Songs
                              .AsNoTracking()
                              .Where(i => i.id == id);

            items = items.Include(i => i.Track);

            var item = items.FirstOrDefault();

            OnSongGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.MimmMysql.Song> CancelSongChanges(Models.MimmMysql.Song item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnSongUpdated(Models.MimmMysql.Song item);

        public async Task<Models.MimmMysql.Song> UpdateSong(int? id, Models.MimmMysql.Song song)
        {
            OnSongUpdated(song);

            var item = context.Songs
                              .Where(i => i.id == id)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(song);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return song;
        }
    
        partial void OnTrackDeleted(Models.MimmMysql.Track item);

        public async Task<Models.MimmMysql.Track> DeleteTrack(int? id)
        {
            var item = context.Tracks
                              .Where(i => i.id == id)
                              .Include(i => i.Songs)
                              .FirstOrDefault();

            OnTrackDeleted(item);

            context.Tracks.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTrackGet(Models.MimmMysql.Track item);

        public async Task<Models.MimmMysql.Track> GetTrackByid(int? id)
        {
            var items = context.Tracks
                              .AsNoTracking()
                              .Where(i => i.id == id);

            var item = items.FirstOrDefault();

            OnTrackGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.MimmMysql.Track> CancelTrackChanges(Models.MimmMysql.Track item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTrackUpdated(Models.MimmMysql.Track item);

        public async Task<Models.MimmMysql.Track> UpdateTrack(int? id, Models.MimmMysql.Track track)
        {
            OnTrackUpdated(track);

            var item = context.Tracks
                              .Where(i => i.id == id)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(track);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return track;
        }
    
        partial void OnUserDeleted(Models.MimmMysql.User item);

        public async Task<Models.MimmMysql.User> DeleteUser(string email)
        {
            var item = context.Users
                              .Where(i => i.email == email)
                              .FirstOrDefault();

            OnUserDeleted(item);

            context.Users.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnUserGet(Models.MimmMysql.User item);

        public async Task<Models.MimmMysql.User> GetUserByemail(string email)
        {
            var items = context.Users
                              .AsNoTracking()
                              .Where(i => i.email == email);

            var item = items.FirstOrDefault();

            OnUserGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.MimmMysql.User> CancelUserChanges(Models.MimmMysql.User item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnUserUpdated(Models.MimmMysql.User item);

        public async Task<Models.MimmMysql.User> UpdateUser(string email, Models.MimmMysql.User user)
        {
            OnUserUpdated(user);

            var item = context.Users
                              .Where(i => i.email == email)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(user);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return user;
        }
        }
}
