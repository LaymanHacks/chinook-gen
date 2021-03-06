using Chinook.Data.DbCommandProvider;
using Chinook.Data.Repository;
using Chinook.Data.SqlDbCommandProvider;
using SimpleInjector;

namespace Chinook.UI.Web
{
    public class InjectorContainerFactory
    {
        public static Container BuildSimpleInjectorContainer()
        {
            var container = new Container();
            
            container.Register<IDbAlbumCommandProvider, SqlDbAlbumCommandProvider>();
            container.Register<IAlbumRepository, DbAlbumRepository>();

            container.Register<IDbArtistCommandProvider, SqlDbArtistCommandProvider>();
            container.Register<IArtistRepository, DbArtistRepository>();

            container.Register<IDbCustomerCommandProvider, SqlDbCustomerCommandProvider>();
            container.Register<ICustomerRepository, DbCustomerRepository>();

            container.Register<IDbEmployeeCommandProvider, SqlDbEmployeeCommandProvider>();
            container.Register<IEmployeeRepository, DbEmployeeRepository>();
            
            container.Register<IDbGenreCommandProvider, SqlDbGenreCommandProvider>();
            container.Register<IGenreRepository, DbGenreRepository>();
            
            container.Register<IDbInvoiceCommandProvider, SqlDbInvoiceCommandProvider>();
            container.Register<IInvoiceRepository, DbInvoiceRepository>();

            container.Register<IDbInvoiceLineCommandProvider, SqlDbInvoiceLineCommandProvider>();
            container.Register<IInvoiceLineRepository, DbInvoiceLineRepository>();

            container.Register<IDbMediaTypeCommandProvider, SqlDbMediaTypeCommandProvider>();
            container.Register<IMediaTypeRepository, DbMediaTypeRepository>();

            container.Register<IDbPlaylistCommandProvider, SqlDbPlaylistCommandProvider>();
            container.Register<IPlaylistRepository, DbPlaylistRepository>();

            container.Register<IDbPlaylistTrackCommandProvider, SqlDbPlaylistTrackCommandProvider>();
            container.Register<IPlaylistTrackRepository, DbPlaylistTrackRepository>();

            container.Register<IDbTrackCommandProvider, SqlDbTrackCommandProvider>();
            container.Register<ITrackRepository, DbTrackRepository>();
            
            return container;
        }
    }
}