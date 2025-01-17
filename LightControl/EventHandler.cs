﻿using Exiled.API.Enums;
using Exiled.API.Features;
using System.Linq;
using UnityEngine;
using Exiled.Events.EventArgs;

namespace LightControl
{
    internal sealed class EventHandler
    {
        public Plugin plugin;
        public EventHandler(Plugin plugin) => this.plugin = plugin;

        public void OnRoundStarted()
        {
            SetRoomColors();
        }

        public void OnWarheadStopping(StoppingEventArgs ev)
        {
            SetRoomColors();
        }

        public void OnWarheadDetonated()
        {
            SetRoomColors();
        }

        private void SetRoomColors()
        {
            if (plugin.Config.Zones.Count > 0)
                foreach ((ZoneType type, Colors color) in plugin.Config.Zones)
                    foreach (Room room in Map.Rooms.Where(r => r.Zone == type))
                        room.Color = new Color(color.Red / 255f, color.Green / 255f, color.Blue / 255f);

            if (plugin.Config.Rooms.Count > 0)
                foreach ((RoomType type, Colors color) in plugin.Config.Rooms)
                    foreach (Room room in Map.Rooms.Where(r => r.Type == type))
                        room.Color = new Color(color.Red / 255f, color.Green / 255f, color.Blue / 255f);
        }
    }
}
