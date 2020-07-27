using Exiled.API.Interfaces;

namespace BetterPersonnel
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool IsFullRp { get; set; } = false;
        public bool IsMediumRp { get; set; } = false;
        public bool IsLightRp { get; set; } = true;
    }
}