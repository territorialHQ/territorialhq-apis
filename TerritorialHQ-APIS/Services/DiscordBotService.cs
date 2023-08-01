using DSharpPlus;
using DSharpPlus.Entities;
using Newtonsoft.Json.Linq;

namespace TerritorialHQ_APIS.Services
{
    public class DiscordBotService
    {
        private readonly IConfiguration _configuration;
        private readonly DiscordClient _discordClient;

        public DiscordBotService(IConfiguration configuration)
        {
            _configuration = configuration;

            _discordClient = new DiscordClient(new DiscordConfiguration()
            {
                Token = ConfigurationBinder.GetValue<string>(_configuration, "DISCORD_BOTTOKEN"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            _discordClient.ConnectAsync();
        }

        public async Task<DiscordUser> GetDiscordUserAsync(ulong id)
        {
            var user = await _discordClient.GetUserAsync(id);
            return user;
        }
    }
}
