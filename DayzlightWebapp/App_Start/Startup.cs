﻿using DayzlightCommon.Entities;
using DayzlightWebapp.Providers;
using System;
using System.Linq;

namespace DayzlightWebapp
{
    public static class Startup
    {
        public static void Register()
        {
            using (var contextDB = new DbProvider(false))
            {
                contextDB.Database.CreateIfNotExists();
                contextDB.Open();

                using (var transaction = contextDB.Database.BeginTransaction())
                {
                    try
                    {
                        if (contextDB.Admins.Count() == 0)
                        {
                            contextDB.Admins.Add(new AdminEntity()
                            {
                                Login = "admin",
                                Password = "admin",
                                LivemapSettings = new LivemapSettingsEntity()
                                {
                                    MenuExpanded = true,
                                    HideSpawnTp = true,
                                    ClearPathAfterDisconnect = true,
                                    OverlayIconsColor = "666666aa",
                                    OverlayIconsSize = 1,
                                    PlayersPathLength = 10,
                                    TimelineExpanded = true,
                                    MenuGeneralExpanded = true,
                                    MenuPlayersExpanded = true
                                }
                            });
                        }
                        contextDB.SaveChanges();
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}