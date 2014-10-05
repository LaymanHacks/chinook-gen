using Chinook.Data.DbCommandProvider;
using Chinook.Data.Repository;
using Chinook.Data.SqlDbCommandProvider;
using SimpleInjector;

namespace Chinook.Web.UI
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

            container.Register<IDbTrackCommandProvider, SqlDbTrackCommandProvider>();
            container.Register<ITrackRepository, DbTrackRepository>();

            container.Register<IDbGenreCommandProvider, SqlDbGenreCommandProvider>();
            container.Register<IGenreRepository, DbGenreRepository>();

            container.Register<IDbCustomerCommandProvider, SqlDbCustomerCommandProvider>();
            container.Register<ICustomerRepository, DbCustomerRepository>();

            return container;
        }
    }
}