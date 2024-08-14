using System.Collections.Generic;
using _menu = AAMenu.Menu;
using ModKit.Helper;
using ModKit.Internal;
using ModKit.Interfaces;
using Life;
using Mirror;
using Life.Network;
using ModKit.Helper.JobHelper;
using Life.BizSystem;
using Life.UI;
using UnityEngine;
using System;
using AAMenu;

namespace Statut581
{
    public class Statut581 : ModKit.ModKit
    {
        private CustomActivity _customActivity;

        public Statut581(IGameAPI api) : base(api)
        {
            PluginInformations = new PluginInformations(AssemblyHelper.GetName(), "1.0", "Shape581");
        }

        public override void OnPluginInit()
        {
            base.OnPluginInit();
            ModKit.Internal.Logger.LogSuccess($"{PluginInformations.SourceName} v{PluginInformations.Version}", "initialisé");
            InsertMenu();
        }

        public void InsertMenu()
        {
          
            _menu.AddBizTabLine(PluginInformations, new List<Activity.Type> { Activity.Type.None }, null, "Ouverture", (ui) =>
            {
                Player player = PanelHelper.ReturnPlayerFromPanel(ui);
                if (player != null)
                {
                    Nova.server.SendMessageToAll($"<color=#008000>[OUVERTURE] <color=#ffffff>L'entreprise {player.biz.BizName} est désormais ouverte.");

                    player.Notify("SUCCES", "Action éffectuer avec succès.", (NotificationManager.Type.Success));

                }
            });

            _menu.AddBizTabLine(PluginInformations, new List<Activity.Type> { Activity.Type.None }, null, "Fermeture", (ui) =>
            {
                Player player = PanelHelper.ReturnPlayerFromPanel(ui);
                if (player != null)
                {
                    Nova.server.SendMessageToAll($"<color=#800000>[FERMETURE] <color=#ffffff>L'entreprise {player.biz.BizName} est désormais fermé.");

                    player.Notify("SUCCES", "Action éffectuer avec succès.", (NotificationManager.Type.Success));
                }
            });
        }
    }
}
