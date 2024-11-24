using daily_planet_domain.Entities;
using daily_planet_domain.Interface.Repositories;
using daily_planet_infra.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daily_planet_infra.Repositories
{
    public class ContentRepository : BaseAuroraRepository<News>, IContentRepository
    {
        private readonly ILogger<ContentRepository> _logger;
        public ContentRepository(AuroraDbContext context, ILogger<ContentRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task Delete(News contents)
        {
            try
            {
                var query = @"DELETE FROM users WHERE IdUser = 'your-iduser-uuid';";
                await DeleteAsync(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ao Deletar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<News>> Get()
        {
            try
            {
                var query = @"INSERT INTO public.Flower
                              (name, type, description, qr, url, image, labtest, thc, cbd, createdat, updatedat, id_brand, id_strain, id_flower)
                              VALUES('', '', '', '', '', '', false, false, false, '', '', ?, ?, ?);";

                return await GetListAsync(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Insert(IEnumerable<News> contents)
        {
            try
            {
                var query = @"INSERT INTO users (IdUser, IdUserSteam, RealName, GamerTag, Avatar, Avatarmedium, Avatarfull, Email) VALUES 
                            ('your-iduser-uuid', 'your-idusersteam-uuid', 'Real Name', 'GamerTag', 'AvatarURL', 'AvatarMediumURL', 'AvatarFullURL', 'email@example.com');";

                await InsertAsync(query, contents);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Inserir Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Update(IEnumerable<News> contents)
        {
            try
            {
                var query = @"UPDATE users
                              SET 
                                  IdUserSteam = 'new-idusersteam-uuid',
                                  RealName = 'New Real Name',
                                  GamerTag = 'New GamerTag',
                                  Avatar = 'NewAvatarURL',
                                  Avatarmedium = 'NewAvatarMediumURL',
                                  Avatarfull = 'NewAvatarFullURL',
                                  Email = 'newemail@example.com'
                              WHERE 
                                  IdUser = 'your-iduser-uuid';";

                await UpdateAsync(query, contents);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Update Flower: {0}", ex.Message);
                throw;
            }
        }
    }
}
